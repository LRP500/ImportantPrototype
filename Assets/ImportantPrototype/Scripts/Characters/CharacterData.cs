using ImportantPrototype.Weapons;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ImportantPrototype.Characters
{
    public abstract class CharacterData : ScriptableObject
    {
        [SerializeField]
        [TitleGroup("Info")]
        private string _name;

        [Multiline]
        [SerializeField]
        [TitleGroup("Info")]
        private string _description;
        
        [SerializeField]
        [TitleGroup("Stats")]
        private int _health = 1;
        
        [SerializeField]
        [TitleGroup("Stats")]
        private float _movementSpeed = 1;

        [SerializeField]
        [TitleGroup("Stats")]
        private float _characterSize = 1;
        
        [SerializeField]
        [TitleGroup("Stats")]
        private float _pickupRange = 1;
        
        [Space]
        [SerializeField]
        private WeaponData _weapon;

        public string Name => _name;
        public string Description => _description;
        public int Health => _health;
        public float MovementSpeed => _movementSpeed;
        public float CharacterSize => _characterSize;
        public float PickupRange => _pickupRange;
        public WeaponData Weapon => _weapon;
    }
}