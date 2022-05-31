using UnityEngine;

namespace ImportantPrototype.Weapons
{
    public abstract class WeaponShotBehaviour : ScriptableObject
    {
        public virtual void Fire(WeaponData weapon, Vector3 origin, Vector3 direction) { }
        public virtual void Fire(WeaponData weapon, Vector3 origin, Vector3 direction, string tag) { }

        protected static void FireSingle(ProjectileData data, Vector3 origin, Vector3 direction, string tag)
        {
            var instance = Projectile.FromData(data);
            instance.transform.eulerAngles = GetRotation(origin, direction);
            instance.Shoot(origin, direction, tag);
        }

        private static Vector2 GetRotation(Vector2 origin, Vector2 direction)
        {
            // TODO: set projectile rotation
            return Quaternion.identity.eulerAngles;
        }
    }
}