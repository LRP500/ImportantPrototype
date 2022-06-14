using UnityEngine;

namespace ImportantPrototype.Characters
{
    [RequireComponent(typeof(CharacterStats))]
    [RequireComponent(typeof(CharacterDamageable))]
    public class Character : MonoBehaviour
    {
        public CharacterStats Stats { get; private set; }
        public CharacterMovement Motor { get; private set; }
        public CharacterDamageable Damageable { get; private set; }
        public Vector2 Position => transform.position;

        private void Awake()
        {
            Stats = GetComponent<CharacterStats>();
            Motor = GetComponent<CharacterMovement>();
            Damageable = GetComponent<CharacterDamageable>();
            OnInitialize();
        }
        
        protected virtual void OnInitialize() { }
        public virtual void OnDeath() { }
    }
}