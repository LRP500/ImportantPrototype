using ImportantPrototype.Input;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ImportantPrototype.Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [Range(0, 20)]
        [SerializeField]
        private float _speed;
        
        private Rigidbody2D _rigidbody;
        private Vector2 _moveInput;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            this.UpdateAsObservable()
                .Subscribe(_ => ProcessInput())
                .AddTo(gameObject);

            this.FixedUpdateAsObservable()
                .Subscribe(_ => Move())
                .AddTo(gameObject);
        }

        private void ProcessInput()
        {
            _moveInput = PlayerInput.Move.normalized;
        }

        private void Move()
        {
            var speed = _speed * 100 * Time.deltaTime;
            _rigidbody.velocity = _moveInput * speed;
        }
    }
}