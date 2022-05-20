using ImportantPrototype.Interfaces;
using ImportantPrototype.Stats;
using UnityEngine;

namespace ImportantPrototype.Characters
{
    public abstract class Damageable : MonoBehaviour, IDamageable
    {
        public string Name { get; protected set; }
        public ModifiableStat Health { get; protected set; }

        public abstract void Damage(IDamager damager);
    }
}