using System.Collections.Generic;
using ImportantPrototype.Characters;
using ImportantPrototype.Stats.Factories;

namespace ImportantPrototype.Stats
{
    public class CharacterStatCollection : StatCollection
    {
        private static readonly CharacterStatCollectionFactory _factory = new();

        #region Fast Accessors

        private Vital _health;
        private Attribute _movementSpeed;
        private Attribute _pickupRange;
        
        public float Health {
            get {
                _movementSpeed ??= Get<Vital>(CharacterStatType.Health);
                return _movementSpeed.Value;
            }
        }
        
        public float MovementSpeed {
            get {
                _movementSpeed ??= Get<Attribute>(CharacterStatType.MovementSpeed);
                return _movementSpeed.Value;
            }
        }
        
        public float PickupRange {
            get {
                _pickupRange ??= Get<Attribute>(CharacterStatType.PickupRange);
                return _pickupRange.Value;
            }
        }
        
        #endregion Fast Accessors
        
        public static CharacterStatCollection FromCharacterData(CharacterData data)
        {
            var collection = _factory.Create();
            collection.Get<Vital>(CharacterStatType.Health).SetValue(data.Health);
            collection.Get<Attribute>(CharacterStatType.MovementSpeed).SetValue(data.MovementSpeed);
            collection.Get<Attribute>(CharacterStatType.PickupRange).SetValue(data.PickupRange);
            return collection;
        }
        
        public CharacterStatCollection(IReadOnlyList<StatInfo> stats)
        {
            for (int i = 0, length = stats.Count; i < length; i++)
            {
                Add(stats[i], 0);
            }
        }

        private T Get<T>(CharacterStatType type) where T : Stat
        {
            return Get<T>((int) type);
        }
    }
}