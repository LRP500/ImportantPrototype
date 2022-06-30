using System;
using ImportantPrototype.Characters;
using ImportantPrototype.Stats;
using UniRx;
using UnityEngine;

namespace ImportantPrototype.UI.HUD
{
    public class PlayerHealthUI : Gauge
    {
        [SerializeField]
        private PlayerReactiveVariable _player;

        protected override IObservable<(float, float)> ObserveValueChanged()
        {
            var player = _player.Property.Value;
            var health = player.Stats.Get<Vital>(CharacterStatType.Health);
            var maxHealth = health.Property;
            var currentHealth = health.Current.Property;
            return currentHealth.CombineLatest(maxHealth, (x, y) => (x, y));
        }
    }
}