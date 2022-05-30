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
        private GameObjectVariable _projectileHolder;

        public SpriteRenderer Renderer => _renderer;
        public WeaponData Data { get; private set; }

        public static Weapon FromData(WeaponData data)
        {
            var instance = Instantiate(data.Prefab);
            instance.Data = data;
            return instance;
        }

        public void Fire(Vector2 direction, string excludeTag)
        {
            // TODO: Restore exclude tag system
            // TODO: Restore projectile holder system
            // var projectile = CreateProjectile();
            // projectile.Damager.Exclude(_projectileTag);
            
            var origin = _muzzle.position;
            Data.ShotBehaviour.Fire(Data, origin, direction);
        }
    }
}
