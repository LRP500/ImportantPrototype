using System;
using ImportantPrototype.System;
using UniRx;
using UnityEngine;

namespace ImportantPrototype.Weapons
{
    [CreateAssetMenu(menuName = ContextMenuPath.WeaponsFiringModes + "Burst")]
    public class BurstWeaponFiringMode : WeaponFiringMode
    {
        [SerializeField]
        private int _burstSize = 3;
        
        public override IObservable<Unit> FilterInput(Weapon weapon, IObservable<bool> inputStream)
        {
            return Observable.Create<Unit>(observer =>
            {
                return inputStream
                    .DistinctUntilChanged()
                    .Where(x => x)
                    .Subscribe(_ =>
                    {
                        Observable
                            .Timer(TimeSpan.Zero, TimeSpan.FromSeconds(GetFireRate(weapon)))
                            .Repeat()
                            .Take(_burstSize)
                            .Subscribe(_ => observer.OnNext(Unit.Default));
                    });
            });
        }
    }
}