using System.Collections.Generic;
using ImportantPrototype.Interfaces;
using UniRx;
using UnityEngine;

namespace ImportantPrototype.Characters
{
    public class Damager : MonoBehaviour, IDamager
    {
        [SerializeField]
        private float _damage;

        private readonly List<string> _excludedTags = new ();
        
        public float Damage => _damage;
        public readonly ISubject<Unit> OnHit = new Subject<Unit>();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_excludedTags.Contains(other.tag)) return;
            OnHit.OnNext(Unit.Default);
            ApplyDamage(other);
        }
        
        /// <summary>
        /// Apply damage to target on hit if any <see cref="IDamageable"/> where found.
        /// </summary>
        /// <param name="target"></param>
        private void ApplyDamage(Component target)
        {
            var damageableCol = target.GetComponent<DamageableCollider>();
            if (damageableCol == null) return;
            damageableCol.Damageable.Damage(this);
        }

        public void Exclude(string excludedTag)
        {
            _excludedTags.Add(excludedTag);
        }
    }
}