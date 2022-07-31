using ImportantPrototype.System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ImportantPrototype.Gameplay.Familiars
{
    [CreateAssetMenu(menuName = ContextMenuPath.Familiars + "Familiar")]
    public class FamiliarData : ScriptableObject
    {
        [SerializeField]
        private Familiar _prefab;
        
        [SerializeField]
        private FamiliarBehaviour _behaviour;
        
        [SerializeField]
        [TitleGroup("Stats")]
        private float _damage;

        [SerializeField]
        private float _movementSpeed;

        [SerializeField]
        private float _attackSpeed;

        [SerializeField]
        private float _range;

        [SerializeField]
        private float _projectileCount;
        
        public Familiar Prefab => _prefab;
        public FamiliarBehaviour Behaviour => _behaviour;
        public float Damage => _damage;
        public float MovementSpeed => _movementSpeed;
        public float AttackSpeed => _attackSpeed;
    }
}