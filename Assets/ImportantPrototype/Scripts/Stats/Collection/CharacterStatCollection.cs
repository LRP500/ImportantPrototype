using ImportantPrototype.Characters;

namespace ImportantPrototype.Stats
{
    public class CharacterStatCollection : StatCollection
    {
        public CharacterStatCollection(StatCollectionData data)
            : base(data)
        { }
        
        public T Get<T>(CharacterStatType type) where T : Stat
        {
            return Get<T>((int) type);
        }
    }
}