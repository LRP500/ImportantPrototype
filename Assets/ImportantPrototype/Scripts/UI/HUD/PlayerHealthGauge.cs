using System;
using ImportantPrototype.Characters;
using UnityEngine;

namespace ImportantPrototype.UI.HUD
{
    public class PlayerHealthGauge : Gauge
    {
        [SerializeField]
        private PlayerReactiveVariable _player;

        private Player Player => _player.Property.Value;
        protected override IObservable<float> Current => Player.Stats.Health.Value;
        protected override IObservable<float> Max => Player.Stats.MaxHealth.Value;
    }
}