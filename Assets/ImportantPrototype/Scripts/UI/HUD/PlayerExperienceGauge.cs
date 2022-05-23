using System;
using ImportantPrototype.Characters;
using ImportantPrototype.Leveling;
using UniRx;
using UnityEngine;

namespace ImportantPrototype.UI.HUD
{
    public class PlayerExperienceGauge : Gauge
    {
        [SerializeField]
        private PlayerReactiveVariable _player;

        [SerializeField]
        private LevelManager _levelManager;

        protected override IObservable<(float, float)> ObserveValueChanged()
        {
            return _player.Value.Stats.Get("xp").Property
                .SkipLatestValueOnSubscribe()
                .Select(_ => (_levelManager.GetCurrentLevelRatio(), 1f))
                .StartWith(() => (0, 1));
        }
    }
}