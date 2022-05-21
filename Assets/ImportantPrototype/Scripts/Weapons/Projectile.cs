using ImportantPrototype.Characters;
using ImportantPrototype.Interfaces;
using UnityEngine;

namespace ImportantPrototype.Weapons
{
    public class Projectile : MonoBehaviour, IDamager
    {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private float _speed;

        [SerializeField]
        private float _damage;

        public float Damage => _damage;
        
        public void Shoot(Vector2 direction)
        {
            _rigidbody.velocity = direction * _speed;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player")) return;
            Hit(other);
            Destroy(gameObject);
        }
        
        /// <summary>
        /// Apply damage to target on hit if any <see cref="IDamageable"/> where found.
        /// </summary>
        /// <param name="target"></param>
        private void Hit(Component target)
        {
            var damageableCol = target.GetComponent<DamageableCollider>();
            if (damageableCol == null) return;
            damageableCol.Damageable.Damage(this);
        }
    }
}