using UnityEngine;

namespace ImportantPrototype.Characters
{
    public class CharacterRenderer : MonoBehaviour
    {
        [SerializeField]
        private Character _character;

        [SerializeField]
        private Animator _animator;

        protected Character Character => _character;
        protected Animator Animator => _animator;
        
        private void Awake()
        {
            Initialize();
        }
        
        private void Update()
        {
            UpdateFacingDirection();
        }

        protected virtual void Initialize() { }
        protected virtual void UpdateFacingDirection() { }
    }
}