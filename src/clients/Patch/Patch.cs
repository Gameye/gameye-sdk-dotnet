using Newtonsoft.Json.Linq;
using System.Linq;

namespace Gameye.Sdk
{
    public class Patch
    {
        public string[] Path { get; set; }
        public JToken Value { get; set; }
        public string JPath => string.Join(".", Path);
        public string LastPathToken => Path.Last();
    }
}
