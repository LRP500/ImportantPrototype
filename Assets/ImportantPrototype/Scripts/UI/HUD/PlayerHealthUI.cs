using System;
using ImportantPrototype.Characters;
using ImportantPrototype.Stats;
using TMPro;
using UniRx;
using UnityEngine;

namespace ImportantPrototype.UI.HUD
{
    public class PlayerHealthUI : Gauge
    {
        [SerializeField]
        private PlayerReactiveVariable _player;

        [SerializeField]
        private TextMeshProUGUI _text;

        protected override void OnValueChanged((float current, float max) value)
        {
            base.OnValueChanged(value);
            SetValueText(value.current, value.max);
        }

        private void SetValueText(float current, float max)
        {
            var currentText = current.ToString();
            var maxText = $"<alpha=#66>/{max.ToString()}";
            _text.SetText($"{currentText}{maxText}");
        }
        
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