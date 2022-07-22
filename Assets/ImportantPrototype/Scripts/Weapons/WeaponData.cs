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

        [SerializeField]
        [TitleGroup("Audio")]
        private AK.Wwise.Event _fireEvent;

        [TitleGroup("Stats")]
        [SerializeField]
        private float _damage = 1;

        [SerializeField]
        private float _fireRate = 0.5f;

        [SerializeField]
        private float _reloadSpeed = 1;

        [SerializeField]
        private float _range = 20;

        [SerializeField]
        private float _shotSpeed = 2;

        [SerializeField]
        private float _shotSize = 1;

        [MinValue(1)]
        [SerializeField]
        private int _projectiles = 1;
        
        [Range(1, 360)]
        [SerializeField]
        [ShowIf("@ _projectiles > 1")]
        private float _spread;
        
        [SerializeField]
        private float _accuracy = 1;

        public string Name => _name;
        public string Description => _description;
        public WeaponFiringMode FiringMode => _firingMode;
        public WeaponShotBehaviour ShotBehaviour => _shotBehaviour;
        public ProjectileData Projectile => _projectile;
        public Weapon Prefab => _prefab;

        public AK.Wwise.Event FireEvent => _fireEvent;        
        
        public float Damage => _damage;
        public float FireRate => _fireRate;
        public float ReloadSpeed => _reloadSpeed;
        public float Range => _range;
        public float ShotSpeed => _shotSpeed;
        public float ShotSize => _shotSize;
        public float Spread => _spread;
        public float Accuracy => _accuracy;
        public int Projectiles => _projectiles;

        private void OnValidate()
        {
            _spread = _projectiles < 2 ? 0 : _spread;
        }
    }
}