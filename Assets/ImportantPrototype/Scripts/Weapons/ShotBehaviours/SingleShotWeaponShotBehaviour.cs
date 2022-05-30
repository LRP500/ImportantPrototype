using ImportantPrototype.System;
using UnityEngine;

namespace ImportantPrototype.Weapons
{
    [CreateAssetMenu(menuName = ContextMenuPath.WeaponShotBehaviours + "Single Shot")]
    public class SingleShotWeaponShotBehaviour : WeaponShotBehaviour
    {
        public override void Fire(WeaponData weapon, Vector3 origin, Vector3 direction)
        {
            FireSingle(weapon.Projectile, origin, direction);
        }
    }
}