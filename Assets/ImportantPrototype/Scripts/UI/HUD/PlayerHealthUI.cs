using System;
using ImportantPrototype.Characters;
using UniRx;
using UnityEngine;

namespace ImportantPrototype.UI.HUD
{
    public class PlayerHealthUI : Gauge
    {
        [SerializeField]
        private PlayerReactiveVariable _player;

        private Player Player => _player.Property.Value;

        protected override IObservable<(float, float)> ObserveValueChanged()
        {
            var health = Player.Stats.Health;
            var max = health.Property;
            var current = health.Current.Property;
            return current.CombineLatest(max, (x, y) => (x, y));
        }
    }
}