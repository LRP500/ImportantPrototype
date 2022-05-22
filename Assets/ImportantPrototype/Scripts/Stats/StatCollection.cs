using UniRx;

namespace ImportantPrototype.Stats
{
    public class StatCollection
    {
        private readonly ReactiveDictionary<StatType, ModifiableStat> _stats = new ();

        public StatCollection(StatCollectionData data)
        {
            Initialize(data);
        }
        
        private void Initialize(StatCollectionData data)
        {
            foreach (var entry in data.Stats)
            {
                var stat = new ModifiableStat(entry.Stat, entry.Value);
                _stats.Add(entry.Stat, stat);
            }
        }

        public ModifiableStat GetStat(StatType type)
        {
            return GetStat(type.Id);
        }
        
        public ModifiableStat GetStat(string id)
        {
            foreach (var (key, value) in _stats)
            {
                if (key.Id.Equals(id))
                {
                    return value;
                }
            }

            return default;
        }
    }
}
