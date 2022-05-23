using ImportantPrototype.Input;
using UnityEngine;

namespace ImportantPrototype.Characters
{
    public class PlayerMovement : CharacterMovement
    {
        private Vector2 _moveInput;

        private void Update()
        {
            ProcessInput();
        }
        
        private void ProcessInput()
        {
            _moveInput = PlayerInput.Move.normalized;
        }
        
        private void FixedUpdate()
        {
            Move(_moveInput);
        }
    }
}