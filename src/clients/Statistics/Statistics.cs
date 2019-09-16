using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Gameye.Sdk
{
    public class Statistics
    {
        private readonly ImmutableDictionary<string, JToken> statsTree;

        public Statistics(Dictionary<string, JToken> startingTree) { statsTree = startingTree.ToImmutableDictionary(); }

        public Statistics Add<T>(string[] path, T other) where T : JToken
        {
            var newStatsTree = new Dictionary<string, JToken>(statsTree);
            if (path.Length == 0)
                return new Statistics(newStatsTree);

            var jpath = string.Join(".", path);
            newStatsTree.TryGetValue(jpath, out var current);

            switch (current)
            {
                case JObject @object:
                    @object.Merge(other);
                    break;
                case JArray array:
                    array.Merge(other);
                    break;
                default:
                    newStatsTree[jpath] = other.DeepClone();
                    break;
            }

            return new Statistics(newStatsTree);
        }

        public JToken Get(params string[] path)
        {
            var jpath = string.Join(".", path);
            var result = statsTree[jpath];
            return result;
        }

        public Statistics Clone()
        {
            var newStatsTree = new Dictionary<string, JToken>(statsTree);
            return new Statistics(newStatsTree);
        }

        public override string ToString()
        {
            return statsTree.ToString();
        }

    }
}
