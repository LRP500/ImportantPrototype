using UnityEngine;

namespace ImportantPrototype.Characters
{
    public class CharacterRenderer : MonoBehaviour
    {
        [SerializeField]
        private Character _character;

        public Character Character => _character;
        
        private void Awake()
        {
            OnInitialize();
        }
        
        private void Update()
        {
            UpdateFacingDirection();
        }

        protected virtual void OnInitialize() { }
        protected virtual void UpdateFacingDirection() { }
    }
}