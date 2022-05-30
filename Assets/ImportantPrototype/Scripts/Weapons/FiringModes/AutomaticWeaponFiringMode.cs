using System;
using ImportantPrototype.System;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.Weapons
{
    [CreateAssetMenu(menuName = ContextMenuPath.WeaponsFiringModes + "Automatic")]
    public class AutomaticWeaponFiringMode : WeaponFiringMode
    {
        public override IObservable<Unit> FilterInput(WeaponData weapon, IObservable<bool> inputStream)
        {
            return inputStream
                .WhereTrue()
                .ThrottleFirst(TimeSpan.FromSeconds(weapon.FireRate))
                .AsUnitObservable();
        }
    }
}