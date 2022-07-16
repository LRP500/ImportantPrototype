using Sirenix.OdinInspector;
using UnityEngine;

namespace ImportantPrototype.Characters
{
    public class Knockback : MonoBehaviour
    {
        [MinValue(0)]
        [SerializeField]
        private float _strength;

        [SerializeField]
        private Rigidbody2D _rigidbody;
        
        private void ApplyKnockback(Transform other)
        {
            var direction = -(other.position - transform.position).normalized;
            _rigidbody.AddForce(direction * _strength, ForceMode2D.Impulse);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Projectile"))
            {
                ApplyKnockback(other.transform);
            }
        }
    }
}
