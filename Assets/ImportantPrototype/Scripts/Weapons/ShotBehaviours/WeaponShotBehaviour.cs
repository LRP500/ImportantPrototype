using UnityEngine;

namespace ImportantPrototype.Weapons
{
    public abstract class WeaponShotBehaviour : ScriptableObject
    {
        public abstract void Fire(WeaponData weapon, Vector3 origin, Vector3 direction);

        protected static void FireSingle(ProjectileData data, Vector3 origin, Vector3 direction)
        {
            var instance = Projectile.FromData(data);
            instance.Shoot(origin, direction);
        }
    }
}