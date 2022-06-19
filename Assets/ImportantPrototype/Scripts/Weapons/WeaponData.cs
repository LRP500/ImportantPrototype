using ImportantPrototype.System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ImportantPrototype.Weapons
{
    [CreateAssetMenu(menuName = ContextMenuPath.Weapons + "Weapon")]
    public class WeaponData : ScriptableObject
    {
        [SerializeField]
        [TitleGroup("Info")]
        private string _name;

        [Multiline]
        [SerializeField]
        private string _description;

        [SerializeField]
        [TitleGroup("General")]
        private Weapon _prefab;

        [SerializeField]
        private ProjectileData _projectile;

        [SerializeField]
        [TitleGroup("Behaviour")]
        private WeaponFiringMode _firingMode;
        
        [SerializeField]
        private WeaponShotBehaviour _shotBehaviour;

        [TitleGroup("Stats")]
        [SerializeField]
        private float _damage;

        [SerializeField]
        private float _fireRate;

        [SerializeField]
        private float _range;

        [SerializeField]
        private float _shotSpeed;

        [SerializeField]
        private float _reloadSpeed;

        public string Name => _name;
        public string Description => _description;
        public WeaponFiringMode FiringMode => _firingMode;
        public WeaponShotBehaviour ShotBehaviour => _shotBehaviour;
        public ProjectileData Projectile => _projectile;
        public Weapon Prefab => _prefab;

        public float Damage => _damage;
        public float FireRate => _fireRate;
        public float Range => _range;
        public float ShotSpeed => _shotSpeed;
        public float ReloadSpeed => _reloadSpeed;
    }
}