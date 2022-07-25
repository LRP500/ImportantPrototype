using ImportantPrototype.System;
using UnityEngine;

namespace ImportantPrototype.Weapons
{
    [CreateAssetMenu(menuName = ContextMenuPath.WeaponShotBehaviours + "Spread Shot")]
    public class SpreadShotWeaponShotBehaviour : WeaponShotBehaviour
    {
        [SerializeField]
        private float _forwardCompensation = 0.5f;

        public override void Fire(Weapon weapon, Vector3 origin, Vector3 direction, string tag)
        {
            var spread = weapon.Stats.Spread;
            var projectiles = Mathf.FloorToInt(weapon.Stats.Projectiles);
            
            float angle = -(spread / 2);
            float increment = spread / (projectiles - 1);

            for (int i = 0; i < projectiles; i++)
            {
                var newDir = Quaternion.AngleAxis(angle, Vector3.forward) * direction;
                var newOrigin = origin + _forwardCompensation * newDir;
                FireSingle(weapon, newOrigin, newDir, tag);
                angle += increment;
            }
        }
    }
}
