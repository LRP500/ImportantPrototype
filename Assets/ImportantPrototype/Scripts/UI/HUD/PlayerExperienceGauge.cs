using System;
using ImportantPrototype.Characters;
using ImportantPrototype.Stats;
using UniRx;
using UnityEngine;

namespace ImportantPrototype.UI.HUD
{
    public class PlayerExperienceGauge : Gauge
    {
        [SerializeField]
        private PlayerReactiveVariable _player;

        [SerializeField]
        private StatType _statType;
        
        private Player Player => _player.Property.Value;
        protected override IObservable<float> Current => Player.Stats.Get(_statType).Value;
        protected override IObservable<float> Max => Observable.Return(100f);
    }
}