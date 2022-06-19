using System;
using UniRx;
using UnityEngine;

namespace ImportantPrototype.Weapons
{
    public abstract class WeaponFiringMode : ScriptableObject
    {
        protected static TimeSpan GetFireRate(Weapon weapon)
        {
            return TimeSpan.FromSeconds(weapon.Stats.FireRate);
        }

        public abstract IObservable<Unit> FilterInput(Weapon weapon, IObservable<bool> inputStream);
    }
}