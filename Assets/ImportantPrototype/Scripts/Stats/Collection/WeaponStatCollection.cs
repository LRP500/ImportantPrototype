using System.Linq;
using ImportantPrototype.Weapons;

namespace ImportantPrototype.Stats
{
    public class WeaponStatCollection : StatCollection
    {
        public WeaponStatCollection(WeaponData data)
        {
            Add(StatType.Attribute, GetInfo(data, WeaponStatType.FireRate), data.FireRate);
            Add(StatType.Attribute, GetInfo(data, WeaponStatType.Damage), data.Projectile.Damage);
            Add(StatType.Attribute, GetInfo(data, WeaponStatType.Range), data.Projectile.Range);
            Add(StatType.Attribute, GetInfo(data, WeaponStatType.ShotSpeed), data.Projectile.Speed);
        }

        private static WeaponStatInfo GetInfo(WeaponData data, WeaponStatType type)
        {
            return data.Stats.First(x => x.Id == (int) type);
        }
        
        public T Get<T>(WeaponStatType type) where T : Stat
        {
            return Get<T>((int) type);
        }
    }
}