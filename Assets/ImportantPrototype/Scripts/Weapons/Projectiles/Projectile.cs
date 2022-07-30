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

        private ProjectileData Data { get; set; }
        private ProjectileBehaviour Behaviour { get; set; }

        public float Range { get; private set; }
        public float Speed { get; private set; }
        public int Piercing { get; private set; }
        public Vector2 Direction { get; set; }

        public Vector2 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        private Vector2 Rotation
        {
            set => transform.eulerAngles = value;
        }

        public static Projectile FromData(ProjectileData data)
        {
            var instance = Instantiate(data.Prefab);
            instance.Behaviour = Instantiate(data.Behaviour);
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
            Behaviour.Initialize(this);

            if (Range > 0)
            {
                Destroy(gameObject, Range / Speed);
            }
            
            _damager.OnHit
                .Skip(Piercing)
                .Subscribe(OnLastHit)
                .AddTo(gameObject);
        }

        private void Update()
        {
            Behaviour.Refresh(this);
        }
        
        private void OnLastHit(Unit unit)
        {
            _damager.SetCanDamage(false);
            Destroy(gameObject);
        }
        
        public void SetStats(WeaponStatCollection stats)
        {
            SetDamage(stats.Damage);
            SetSize(stats.ShotSize);
            Piercing = (int) stats.Piercing;
            Speed = stats.ShotSpeed;
            Range = stats.Range;
        }

        private void SetDamage(float damage)
        {
            _damager.SetDamage(damage);
        }

        private void SetSize(float size)
        {
            transform.localScale *= size;
        }
    }
}