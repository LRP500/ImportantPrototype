using UnityEngine;

namespace ImportantPrototype.Characters
{
    [RequireComponent(typeof(CharacterStats))]
    public class Character : MonoBehaviour
    {
        public CharacterStats Stats { get; private set; }
        public CharacterMovement Motor { get; private set; }
        public Vector2 Position => transform.position;

        private void Awake()
        {
            Stats = GetComponent<CharacterStats>();
            Motor = GetComponent<CharacterMovement>();
            OnInitialize();
        }
        
        protected virtual void OnInitialize() { }
        public virtual void OnDeath() { }
    }
}