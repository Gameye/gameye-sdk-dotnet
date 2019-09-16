
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Gameye.Sdk.Tests
{
    [TestClass]
    public class PatchDocumentTests
    {
        private PatchDocument CreatePatchDocument()
        {
            var json = File.ReadAllText("Content/patch.json");
            var document = JsonConvert.DeserializeObject(json) as JObject;
            return new PatchDocument(document);
        }

        [TestMethod]
        public void AppliesValuePatch()
        {
            var patchDocument = CreatePatchDocument();

            Assert.AreEqual("value", patchDocument.GetAt<string>("keyFour.subKeyThree.key"));

            patchDocument.Patch(new Patch
            {
                Path = new string[] { "keyFour", "subKeyThree", "key" },
                Value = "newvalue"
            });

            Assert.AreEqual(1, patchDocument.GetAt<int>("keyFour.subKeyOne"));
            Assert.AreEqual("newvalue", patchDocument.GetAt<string>("keyFour.subKeyThree.key"));
        }
    }
}
