using ImportantPrototype.System;
using UnityEngine;

namespace ImportantPrototype.Weapons
{
    [CreateAssetMenu(menuName = ContextMenuPath.WeaponShotBehaviours + "Single Shot")]
    public class SingleShotWeaponShotBehaviour : WeaponShotBehaviour
    {
        public override void Fire(Weapon weapon, Vector3 origin, Vector3 direction, string tag)
        {
            FireSingle(weapon, origin, direction, tag);
        }
    }
}