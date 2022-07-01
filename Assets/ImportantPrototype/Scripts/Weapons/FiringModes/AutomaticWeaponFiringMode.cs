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
            return Observable.Create<Unit>(observer =>
            {
                var lastShot = Time.time;
                var disposable = new SerialDisposable();
                return inputStream
                    .DistinctUntilChanged()
                    .SubscribeTwoStates(
                    () =>
                    {
                        disposable.Disposable = inputStream.WhereTrue()
                            .Subscribe(_ =>
                            {
                                var timer = GetFireRate(weapon);
                                if (!(Time.time - lastShot > timer)) return;
                                lastShot = Time.time;
                                observer.OnNext(Unit.Default);
                            });
                    },
                    () => disposable.Clear());
            });
        }
    }
}