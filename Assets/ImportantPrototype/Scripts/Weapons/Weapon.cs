using UnityEngine;
using UnityTools.Runtime.Variables;

namespace ImportantPrototype.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _renderer;
        
        [SerializeField]
        private Transform _muzzle;

        [SerializeField]
        private Projectile _projectile;

        [SerializeField]
        private GameObjectVariable _projectileHolder;

        public SpriteRenderer Renderer => _renderer;
        
        public void Fire(Vector2 direction)
        {
            var projectile = CreateProjectile();
            projectile.Shoot(direction);
        }

        public void Fire(Vector2 direction, string excludedTag)
        {
            var projectile = CreateProjectile();
            projectile.Damager.Exclude(excludedTag);
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
