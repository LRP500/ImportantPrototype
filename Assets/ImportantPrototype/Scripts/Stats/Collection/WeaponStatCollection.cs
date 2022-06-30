using System.Collections.Generic;
using ImportantPrototype.Stats.Manager;
using ImportantPrototype.Weapons;

namespace ImportantPrototype.Stats
{
    public class WeaponStatCollection : StatCollection
    {
        private static readonly WeaponStatCollectionFactory _factory = new();

        #region Fast Accessors

        private Attribute _fireRate;
        private Attribute _damage;
        private Attribute _shotSize;
        private Attribute _shotSpeed;
        
        public float Damage {
            get {
                _damage ??= Get<Attribute>(WeaponStatType.Damage);
                return _damage.Value;
            }
        }
        
        public float FireRate {
            get {
                _fireRate ??= Get<Attribute>(WeaponStatType.FireRate);
                return _fireRate.Value;
            }
        }
        
        public float ShotSize {
            get {
                _shotSize ??= Get<Attribute>(WeaponStatType.ShotSize);
                return _shotSize.Value;
            }
        }
        
        public float ShotSpeed {
            get {
                _shotSpeed ??= Get<Attribute>(WeaponStatType.ShotSpeed);
                return _shotSpeed.Value;
            }
        }
        
        #endregion Fast Accessors
        
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

        private T Get<T>(WeaponStatType type) where T : Stat
        {
            return Get<T>((int) type);
        }
    }
}