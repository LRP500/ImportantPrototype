using System;
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

        public float Range { get; private set; }
        public float Speed { get; private set; }
        public Vector2 Direction { get; private set; }
        private ProjectileData Data { get; set; }

        private Vector2 Position
        {
            set => transform.position = value;
        }

        private Vector2 Rotation
        {
            set => transform.eulerAngles = value;
        }

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
            Data.Behaviour.Initialize(this);

            _damager.OnHit.First()
                .Subscribe(OnHit)
                .AddTo(gameObject);

            if (Range > 0)
            {
                Destroy(gameObject, Range / Speed);
            }
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
            SetRange(stats.Range);
        }

        private void SetDamage(float damage)
        {
            _damager.SetDamage(damage);
        }

        public void SetSpeed(float speed)
        {
            Speed = speed;
        }

        private void SetSize(float size)
        {
            transform.localScale *= size;
        }
        
        private void SetRange(float range)
        {
            Range = range;
        }
    }
}