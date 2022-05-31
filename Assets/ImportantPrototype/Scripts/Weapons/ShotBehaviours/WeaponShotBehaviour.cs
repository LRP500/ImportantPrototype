﻿using UnityEngine;

namespace ImportantPrototype.Weapons
{
    public abstract class WeaponShotBehaviour : ScriptableObject
    {
        public virtual void Fire(WeaponData weapon, Vector3 origin, Vector3 direction, string tag) { }

        protected static void FireSingle(ProjectileData data, Vector3 origin, Vector3 direction, string tag)
        {
            var instance = Projectile.FromData(data);
            var rotation = GetRotation(direction);
            instance.Initialize(origin, direction, rotation);
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