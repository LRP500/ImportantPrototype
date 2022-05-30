using ImportantPrototype.System;
using UnityEngine;

namespace ImportantPrototype.Weapons
{
    [CreateAssetMenu(menuName = ContextMenuPath.Weapons + "Weapon")]
    public class WeaponData : ScriptableObject
    {
        [SerializeField]
        private string _name;

        [Multiline]
        [SerializeField]
        private string _description;

        [Space]
        [SerializeField]
        private WeaponFiringMode _firingMode;
        
        [SerializeField]
        private WeaponShotBehaviour _shotBehaviour;

        [SerializeField]
        private ProjectileData _projectile;

        [SerializeField]
        private Weapon _prefab;
        
        [Space]
        [SerializeField]
        private float _fireRate;
        
        [SerializeField]
        private float _accuracy;

        public string Name => _name;
        public string Description => _description;
        public WeaponFiringMode FiringMode => _firingMode;
        public WeaponShotBehaviour ShotBehaviour => _shotBehaviour;
        public ProjectileData Projectile => _projectile;
        public Weapon Prefab => _prefab;
        public float FireRate => _fireRate;
        public float Accuracy => _accuracy;
    }
}