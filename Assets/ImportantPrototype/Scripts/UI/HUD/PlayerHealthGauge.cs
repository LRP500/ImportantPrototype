using ImportantPrototype.Characters;
using ImportantPrototype.Stats;
using UnityEngine;

namespace ImportantPrototype.UI.HUD
{
    public class PlayerHealthGauge : Gauge
    {
        [SerializeField]
        private PlayerReactiveVariable _player;

        private Player Player => _player.Property.Value;
        protected override ModifiableStat Health => Player.Stats.Health;
        protected override ModifiableStat MaxHealth => Player.Stats.MaxHealth;
    }
}