using UnityEngine;
using ContextMenuPath = ImportantPrototype.System.ContextMenuPath;

namespace ImportantPrototype.Weapons
{
    [CreateAssetMenu(menuName = ContextMenuPath.Weapons + "Projectile")]
    public class ProjectileData : ScriptableObject
    {
        [SerializeField]
        private Projectile _prefab;
        
        [SerializeField]
        private ProjectileBehaviour _behaviour;
        
        public Projectile Prefab => _prefab;
        public ProjectileBehaviour Behaviour => _behaviour;
    }
}