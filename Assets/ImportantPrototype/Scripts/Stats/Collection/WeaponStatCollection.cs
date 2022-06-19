using System.Collections.Generic;
using ImportantPrototype.Scripts.Stats.Manager;
using ImportantPrototype.Weapons;

namespace ImportantPrototype.Stats
{
    public class WeaponStatCollection : StatCollection
    {
        private static readonly WeaponStatCollectionFactory _factory = new();

        public float FireRate => Get<Attribute>(WeaponStatType.FireRate).Value;
        public float Damage => Get<Attribute>(WeaponStatType.Damage).Value;
        public float ShotSize => Get<Attribute>(WeaponStatType.ShotSize).Value;
        public float ShotSpeed => Get<Attribute>(WeaponStatType.ShotSpeed).Value;
        
        public static WeaponStatCollection FromWeaponData(WeaponData data)
        {
            var collection = _factory.Create();
            collection.Get<Attribute>(WeaponStatType.Damage).SetValue(data.Damage);
            collection.Get<Attribute>(WeaponStatType.FireRate).SetValue(data.FireRate);
            collection.Get<Attribute>(WeaponStatType.ReloadSpeed).SetValue(data.ReloadSpeed);
            collection.Get<Attribute>(WeaponStatType.Range).SetValue(data.Range);
            collection.Get<Attribute>(WeaponStatType.ShotSpeed).SetValue(data.ShotSpeed);
            collection.Get<Attribute>(WeaponStatType.ShotSize).SetValue(data.ShotSize);
            return collection;
        }
        
        public WeaponStatCollection(IReadOnlyList<StatInfo> stats)
        {
            for (int i = 0, length = stats.Count; i < length; i++)
            {
                Add(stats[i], 0);
            }
        }

        public T Get<T>(WeaponStatType type) where T : Stat
        {
            return Get<T>((int) type);
        }
    }
}