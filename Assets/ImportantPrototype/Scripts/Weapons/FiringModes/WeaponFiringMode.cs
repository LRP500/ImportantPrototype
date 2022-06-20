using System;
using UniRx;
using UnityEngine;

namespace ImportantPrototype.Weapons
{
    public abstract class WeaponFiringMode : ScriptableObject
    {
        protected static float GetFireRate(Weapon weapon)
        {
            return 1f / weapon.Stats.FireRate;
        }

        public abstract IObservable<Unit> FilterInput(Weapon weapon, IObservable<bool> inputStream);
    }
}