using UnityEngine;

namespace ImportantPrototype.Weapons
{
    public abstract class WeaponShotBehaviour : ScriptableObject
    {
        public virtual void Fire(Weapon weapon, Vector3 origin, Vector3 direction, string tag) { }

        protected static void FireSingle(Weapon weapon, Vector3 origin, Vector3 direction, string tag)
        {
            var instance = Projectile.FromData(weapon.Data.Projectile);
            var rotation = GetRotation(direction);
            instance.Initialize(origin, direction, rotation);
            instance.SetStats(weapon.Stats);
            instance.SetTag(tag);
            instance.Shoot();
        }

        private static Vector2 GetRotation(Vector3 direction)
        {
            var angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            return Quaternion.AngleAxis(angle, Vector3.forward).eulerAngles;
        }
    }
}