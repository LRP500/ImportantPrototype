using System;
using ImportantPrototype.Characters;
using ImportantPrototype.Leveling;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;
using UnityTools.Runtime.Extensions;
using Attribute = ImportantPrototype.Stats.Attribute;

namespace ImportantPrototype.UI.HUD
{
    public class PlayerExperienceUI : Gauge
    {
        [SerializeField]
        private PlayerReactiveVariable _player;

        [FormerlySerializedAs("_levelManager")]
        [SerializeField]
        private PlayerLevelManager _playerLevelManager;

        protected override IObservable<(float, float)> ObserveValueChanged()
        {
            return _player.Value.Stats.Collection
                .Get<Attribute>((int) CharacterStatType.Experience).Property
                .SkipFirst()
                .Select(_ => (_playerLevelManager.GetCurrentLevelRatio(), 1f))
                .StartWith(() => (0, 1));
        }
    }
}