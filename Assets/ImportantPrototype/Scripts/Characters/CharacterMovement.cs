using UnityEngine;

namespace ImportantPrototype.Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class CharacterMovement : MonoBehaviour
    {
        [Range(0, 20)]
        [SerializeField]
        private float _speed;

        private Rigidbody2D Rigidbody { get; set; }

        private Vector2 _velocity;
        
        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
        }
        
        public void Move(Vector2 direction)
        {
            Rigidbody.velocity = direction * _speed;
        }
    }
}