using ImportantPrototype.Input;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ImportantPrototype.Characters
{
    public class PlayerMovement : CharacterMovement
    {
        private Vector2 _moveInput;
        
        private void Start()
        {
            this.UpdateAsObservable()
                .Subscribe(_ => ProcessInput())
                .AddTo(gameObject);

            this.FixedUpdateAsObservable()
                .Subscribe(_ => Move(_moveInput))
                .AddTo(gameObject);
        }

        private void ProcessInput()
        {
            _moveInput = PlayerInput.Move.normalized;
        }
    }
}