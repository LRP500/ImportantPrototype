using ImportantPrototype.Interfaces;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace ImportantPrototype.Gameplay
{
    public class Damageable : MonoBehaviour, IDamageable
    {
        [MinValue(0)]
        [SerializeField]
        private double _health;
        
        private readonly ReactiveProperty<bool> _isDamageable = new (true);
        public IReadOnlyReactiveProperty<bool> IsDamageable => _isDamageable;

        public ISubject<Unit> OnDeath { get; } = new Subject<Unit>();
        public ISubject<float> OnDamageTaken { get; } = new Subject<float>();

        public virtual double Health => _health;

        public void Damage(IDamager damager)
        {
            if (!IsDamageable.Value) return;
         
            ApplyDamage(damager.Damage);
            OnDamageTaken.OnNext(damager.Damage);
            
            if (Health <= 0)
            {
                OnDeath.OnNext(Unit.Default);
            }
        }

        protected virtual void ApplyDamage(float damage)
        {
            _health -= damage;
        }
        
        public void SetDamageable(bool canDamage)
        {
            _isDamageable.Value = canDamage;
        }
    }
}

// public class HitInfo
// {
//     public float damage;
//     public IDamager damager;
//     public Collider2D collider;
// }