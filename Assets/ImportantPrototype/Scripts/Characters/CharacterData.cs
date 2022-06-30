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
        private int _health;
        
        [SerializeField]
        [TitleGroup("Stats")]
        private float _movementSpeed;

        [SerializeField]
        [TitleGroup("Stats")]
        private float _pickupRange;
        
        [Space]
        [SerializeField]
        private WeaponData _weapon;

        public string Name => _name;
        public string Description => _description;
        public int Health => _health;
        public float MovementSpeed => _movementSpeed;
        public float PickupRange => _pickupRange;
        public WeaponData Weapon => _weapon;
    }
}