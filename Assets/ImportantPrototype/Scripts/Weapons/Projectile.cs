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
        
        [SerializeField]
        private float _speed;

        public Damager Damager => _damager;
        
        public void Shoot(Vector2 direction)
        {
            _rigidbody.velocity = direction * _speed;
            _damager.OnHit.First().Subscribe(OnHit);
        }

        private void OnHit(Unit unit)
        {
            Destroy(gameObject);
        }
    }
}