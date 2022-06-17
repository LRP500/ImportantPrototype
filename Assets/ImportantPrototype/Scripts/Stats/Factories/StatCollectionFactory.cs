using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ImportantPrototype.Stats
{
    public abstract class StatCollectionFactory<T> where T : StatCollection
    {
        protected abstract string AssetPath { get; }

        protected List<StatInfo> Stats { get; }

        protected StatCollectionFactory()
        {
            Stats = LoadStats().ToList();
        }

        private IEnumerable<StatInfo> LoadStats()
        {
            return Resources.LoadAll<StatInfo>(AssetPath);
        }
        
        public abstract T Create();
    }
}