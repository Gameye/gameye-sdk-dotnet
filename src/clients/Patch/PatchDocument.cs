using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Gameye.Sdk
{
    public class PatchDocument
    {
        private readonly JObject document = new JObject();

        public PatchDocument(JObject document)
        {
            this.document = document.DeepClone() as JObject;
        }

        public PatchDocument()
        {
            document = new JObject();
        }

        private void FillPath(IEnumerable<string> path)
        {
            var existing = document.SelectToken(string.Join(".", path));
            if (existing != null)
            {
                return;
            }

            JObject currentParent = document;
            foreach (var pathSection in path)
            {
                currentParent.TryGetValue(pathSection, out var found);
                if (found == null)
                {
                    currentParent[pathSection] = new JObject();
                    found = currentParent[pathSection];
                }

                currentParent = found as JObject;
            }
        }

        public T GetAt<T>(string jpath)
        {
            var existing = document.SelectToken(jpath);
            return existing == null ? default : existing.ToObject<T>();
        }

        private JObject GetObjectAt(IEnumerable<string> path)
        {
            return document.SelectToken(string.Join(".", path)) as JObject;
        }

        public void Patch(Patch patch)
        {
            if (patch.Path.Length == 0)
            {
                document.Merge(patch.Value);
                return;
            }

            var parentPath = patch.Path.Take(patch.Path.Length - 1);
            FillPath(parentPath);
            var parent = GetObjectAt(parentPath);
            parent[patch.LastPathToken] = patch.Value.DeepClone();
        }

        public PatchDocument Clone()
        {
            return new PatchDocument(document);
        }
    }
}
