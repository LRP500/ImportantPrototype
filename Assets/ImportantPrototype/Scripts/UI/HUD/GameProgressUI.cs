using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.UI;
using UnityTools.Runtime.Variables;

namespace ImportantPrototype.UI.HUD
{
    public class GameProgressUI : Element
    {
        [SerializeField]
        private TextMeshProUGUI _currentWaveText;

        [SerializeField]
        private TextMeshProUGUI _durationText;

        [SerializeField]
        private IntReactiveVariable _currentWave;

        [SerializeField]
        private FloatVariable _gameStartTime;

        private readonly SerialDisposable _timeDisposable = new ();
        private readonly SerialDisposable _waveDisposable = new ();
        
        public override void Initialize()
        {
            _timeDisposable.AddTo(gameObject);
            _waveDisposable.AddTo(gameObject);
        }
        
        protected override void OnShow()
        {
            _timeDisposable.Disposable = Observable
                .Timer(TimeSpan.Zero, TimeSpan.FromSeconds(1))
                .Subscribe(_ => UpdateDuration());

            _waveDisposable.Disposable = _currentWave
                .ObserveValueChanged()
                .Subscribe(UpdateWave);
        }

        private void UpdateDuration()
        {
            var duration = Time.time - _gameStartTime;
            _durationText.SetText(FormatTime(duration));
        }

        private void UpdateWave(int wave)
        {
            _currentWaveText.SetText($"Wave {(wave + 1).ToString()}");
        }

        private static string FormatTime(float time)
        {
            int minutes = (int) time / 60 ;
            int seconds = (int) time - 60 * minutes;
            return $"{minutes:00}:{seconds:00}";
        }
    }
}
