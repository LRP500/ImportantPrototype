using System;
using ImportantPrototype.Characters;
using ImportantPrototype.Leveling;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.UI.HUD
{
    public class PlayerExperienceUI : Gauge
    {
        [SerializeField]
        private PlayerReactiveVariable _player;

        [SerializeField]
        private LevelManager _levelManager;

        protected override IObservable<(float, float)> ObserveValueChanged()
        {
            return _player.Value.Stats
                .ObserveValueChanged("xp")
                .SkipFirst()
                .Select(_ => (_levelManager.GetCurrentLevelRatio(), 1f))
                .StartWith(() => (0, 1));
        }
    }
}