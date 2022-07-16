using ImportantPrototype.Gameplay;
using ImportantPrototype.Stats;
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

        public float Speed { get; private set; }
        public Vector2 Direction { get; private set; }

        private Vector2 Position
        {
            set => transform.position = value;
        }

        private Vector2 Rotation
        {
            set => transform.eulerAngles = value;
        }

        private ProjectileData Data { get; set; }

        public static Projectile FromData(ProjectileData data)
        {
            var instance = Instantiate(data.Prefab);
            instance.Data = data;
            return instance;
        }

        public void Initialize(Vector2 origin, Vector2 direction, Vector3 rotation)
        {
            Position = origin;
            Rotation = rotation;
            Direction = direction;
        }

        public void SetTag(string projectileTag)
        {
            _damager.Exclude(projectileTag);
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
        
        public void SetStats(WeaponStatCollection stats)
        {
            SetDamage(stats.Damage);
            SetSpeed(stats.ShotSpeed);
            SetSize(stats.ShotSize);
        }

        private void SetDamage(float damage)
        {
            _damager.SetDamage(damage);
        }

        private void SetSpeed(float speed)
        {
            Speed = speed;
        }

        private void SetSize(float size)
        {
            transform.localScale *= size;
        }
    }
}