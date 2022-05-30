using ImportantPrototype.Characters;
using UniRx;
using UnityEngine;

namespace ImportantPrototype.Weapons
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private Damager _damager;
        
        public Rigidbody2D Rigidbody => _rigidbody;

        public Vector2 Origin { get; private set; }
        public Vector2 Direction { get; private set; }

        public Vector2 Position
        {
            get => transform.position;
            set => transform.position = value;
        }
        
        public ProjectileData Data { get; private set; }

        public static Projectile FromData(ProjectileData data)
        {
            var instance = Instantiate(data.Prefab);
            instance.Data = data;
            return instance;
        }

        private void Awake()
        {
            _damager.OnHit.First().Subscribe(OnHit);
        }

        public void Shoot(Vector2 direction, Vector2 origin)
        {
            Origin = origin;
            Position = origin;
            Direction = direction.normalized;
            Data.Behaviour.Initialize(this);
        }

        private void Update()
        {
            Data.Behaviour.Refresh(this);
        }
        
        private void OnHit(Unit unit)
        {
            Destroy(gameObject);
        }
    }
}