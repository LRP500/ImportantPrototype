using ImportantPrototype.System;
using UnityEngine;

namespace ImportantPrototype.Weapons
{
    [CreateAssetMenu(menuName = ContextMenuPath.WeaponShotBehaviours + "Spread Shot")]
    public class SpreadShotWeaponShotBehaviour : WeaponShotBehaviour
    {
        [Range(1, 360)]
        [SerializeField]
        private float _spreadAngle = 60f;

        [Range(2, 16)]
        [SerializeField]
        private int _projectileCount = 3;

        [SerializeField]
        private float _forwardCompensation = 0.5f;

        public override void Fire(WeaponData weapon, Vector3 origin, Vector3 direction, string tag)
        {
            float angle = -(_spreadAngle / 2); 
            float increment = _spreadAngle / (_projectileCount - 1);

            for (int i = 0; i < _projectileCount; i++)
            {
                var newDir = Quaternion.AngleAxis(angle, Vector3.up) * direction;
                var newOrigin = origin + (_forwardCompensation * newDir);
                FireSingle(weapon.Projectile, newOrigin, newDir, tag);
                angle += increment;
            }
        }
    }
}
