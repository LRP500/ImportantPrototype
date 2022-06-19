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
        public override IObservable<Unit> FilterInput(Weapon weapon, IObservable<bool> inputStream)
        {
            // return inputStream
            //     .WhereTrue()
            //     .Zip(inputStream
            //         .WhereTrue()
            //         .ThrottleFirst(GetFireRate(weapon))
            //         .Repeat(), (input, first) => input && first)
            //     .AsUnitObservable();

            return inputStream
                .WhereTrue()
                .ThrottleFirst(GetFireRate(weapon))
                .AsUnitObservable();
        }
    }
}