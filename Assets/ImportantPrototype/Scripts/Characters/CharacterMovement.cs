using UnityEngine;

namespace ImportantPrototype.Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class CharacterMovement : MonoBehaviour
    {
        [Range(0, 20)]
        [SerializeField]
        private float _speed;

        private Rigidbody2D _rigidbody;

        public Vector2 Velocity { get; private set; }
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnDisable()
        {
            _rigidbody.velocity = Vector2.zero;
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }
        
        public void Move(Vector2 direction)
        {
            Velocity = direction * _speed;
            _rigidbody.position += Velocity * Time.deltaTime;
            // _rigidbody.velocity = Velocity;
        }
    }
}