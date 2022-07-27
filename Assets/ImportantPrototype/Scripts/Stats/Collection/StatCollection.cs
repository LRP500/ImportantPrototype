using ImportantPrototype.Stats.Factory;
using UniRx;

namespace ImportantPrototype.Stats
{
    public abstract class StatCollection
    {
        private readonly ReactiveDictionary<StatInfo, Stat> _stats = new ();

        protected void Add(StatInfo info, float value)
        {
            _stats.Add(info, StatFactory.Create(info, value));
        }
        
        public T Get<T>(int id) where T : Stat
        {
            foreach (var (key, value) in _stats)
            {
                if (key.Id == id)
                {
                    return value as T;
                }
            }

            return default;
        }
    }
}
