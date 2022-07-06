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
        private Attribute _projectiles;
        private Attribute _spread;
        private Attribute _accuracy;
        
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
        
        public float Projectiles {
            get {
                _projectiles ??= Get<Attribute>(WeaponStatType.Projectiles);
                return _projectiles.Value;
            }
        }
        
        public float Spread {
            get {
                _spread ??= Get<Attribute>(WeaponStatType.Spread);
                return _spread.Value;
            }
        }
        
        public float Accuracy {
            get {
                _accuracy ??= Get<Attribute>(WeaponStatType.Accuracy);
                return _accuracy.Value;
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
            collection.Get<Attribute>(WeaponStatType.Projectiles).SetValue(data.Projectiles);
            collection.Get<Attribute>(WeaponStatType.Spread).SetValue(data.Spread);
            collection.Get<Attribute>(WeaponStatType.Accuracy).SetValue(data.Accuracy);
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