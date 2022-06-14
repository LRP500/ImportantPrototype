using System;
using UniRx;
using UnityEngine;

namespace ImportantPrototype.Weapons
{
    public abstract class WeaponFiringMode : ScriptableObject
    {
        public abstract IObservable<Unit> FilterInput(Weapon weapon, IObservable<bool> inputStream);
    }
}