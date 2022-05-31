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
        public Damager Damager => _damager;

        public Vector2 Origin { get; private set; }
        public Vector2 Direction { get; private set; }

        public Vector2 Position
        {
            get => transform.position;
            set => transform.position = value;
        }
        
        public Vector2 Rotation
        {
            get => transform.eulerAngles;
            set => transform.eulerAngles = value;
        }
        
        public ProjectileData Data { get; private set; }

        public static Projectile FromData(ProjectileData data)
        {
            var instance = Instantiate(data.Prefab);
            instance.Data = data;
            return instance;
        }

        public void Initialize(Vector2 origin, Vector2 direction, Vector2 rotation)
        {
            Origin = origin;
            Position = origin;
            Rotation = rotation;
            Direction = direction;
            Damager.SetDamage(Data.Damage);
        }

        public void SetTag(string projectileTag)
        {
            Damager.Exclude(projectileTag);
        }
        
        public void Shoot()
        {
            _damager.OnHit.First().Subscribe(OnHit);
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