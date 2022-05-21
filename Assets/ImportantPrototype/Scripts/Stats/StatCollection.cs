using UniRx;

namespace ImportantPrototype.Stats
{
    public class StatCollection
    {
        private readonly ReactiveCollection<ModifiableStat> _stats = new ();
        public IReadOnlyReactiveCollection<ModifiableStat> Stats => _stats;

        public StatCollection(StatCollectionData data)
        {
            Initialize(data);
        }
        
        private void Initialize(StatCollectionData data)
        {
            foreach (var stat in data.Stats)
            {
                _stats.Add(new ModifiableStat(stat.type, stat.value));
            }
        }

        public ModifiableStat GetStat(string id)
        {
            for (int i = 0, len = _stats.Count; i < len; ++i)
            {
                if (_stats[i].Type.Id.Equals(id))
                {
                    return _stats[i];
                }
            }

            return default;
        }
    }
}
