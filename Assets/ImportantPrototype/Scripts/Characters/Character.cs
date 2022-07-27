using UnityEngine;

namespace ImportantPrototype.Characters
{
    [RequireComponent(typeof(CharacterStats))]
    [RequireComponent(typeof(CharacterDamageable))]
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private CharacterData _data;

        public CharacterData Data => _data;
        public CharacterStats Stats { get; private set; }
        public CharacterMovement Motor { get; private set; }
        public CharacterDamageable Damageable { get; private set; }
        public Vector2 Position => transform.position;

        protected virtual void Awake()
        {
            Stats = GetComponent<CharacterStats>();
            Motor = GetComponent<CharacterMovement>();
            Damageable = GetComponent<CharacterDamageable>();
        }

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            OnInitialize();
        }
        
        protected virtual void OnInitialize() { }
        public virtual void OnDeath() { }
    }
}