using UnityEngine;
using ContextMenuPath = ImportantPrototype.System.ContextMenuPath;

namespace ImportantPrototype.Weapons
{
    [CreateAssetMenu(menuName = ContextMenuPath.Weapons + "Projectile")]
    public class ProjectileData : ScriptableObject
    {
        [SerializeField]
        private float _damage = 10f;

        [SerializeField]
        private float _speed = 5f;

        [SerializeField]
        private float _range = 100f;

        [SerializeField]
        private Projectile _prefab;
        
        [SerializeField]
        private ProjectileBehaviour _behaviour;
        
        public float Speed => _speed;
        public float Range => _range;
        public Projectile Prefab => _prefab;
        public ProjectileBehaviour Behaviour => _behaviour;
    }
}