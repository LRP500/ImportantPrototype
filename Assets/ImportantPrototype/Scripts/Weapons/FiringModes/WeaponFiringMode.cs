using System;
using UniRx;
using UnityEngine;

namespace ImportantPrototype.Weapons
{
    public abstract class WeaponFiringMode : ScriptableObject
    {
        public abstract IObservable<Unit> FilterInput(WeaponData weapon, IObservable<bool> inputStream);
    }
}