﻿using ImportantPrototype.Interfaces;
using ImportantPrototype.Stats;
using UniRx;
using UnityEngine;

namespace ImportantPrototype.Characters
{
    public abstract class Damageable : MonoBehaviour, IDamageable
    {
        // public class HitInfo
        // {
        //     public float damage;
        //     public IDamager damager;
        //     public Collider2D collider;
        // }
        
        public readonly ISubject<Unit> OnDeath = new Subject<Unit>();
        public readonly ISubject<float> OnDamageTaken = new Subject<float>();

        private readonly ReactiveProperty<bool> _canDamage = new (true);
        public IReadOnlyReactiveProperty<bool> CanDamage => _canDamage;
        
        public Attribute Health { get; protected set; }
        
        public void Damage(IDamager damager)
        {
            if (!CanDamage.Value) return;
            
            Health.Remove(damager.Damage);
            OnDamageTaken.OnNext(damager.Damage);
            
            if (Health.Value <= 0)
            {
                OnDeath.OnNext(Unit.Default);
            }
        }
        
        public void SetCanDamage(bool canDamage)
        {
            _canDamage.Value = canDamage;
        }
    }
}