using UnityEngine;
using UnityTools.Runtime.Variables;

namespace ImportantPrototype.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private Transform _muzzle;

        [SerializeField]
        private Projectile _projectile;

        [SerializeField]
        private GameObjectVariable _projectileHolder;
        
        public void Fire(Vector2 direction)
        {
            var projectile = CreateProjectile();
            projectile.Shoot(direction);
        }

        private Projectile CreateProjectile()
        {
            var projectile = Instantiate(_projectile, _muzzle.position, transform.rotation);
            projectile.transform.SetParent(_projectileHolder.Value.transform, true);
            return projectile;
        }
    }
}
