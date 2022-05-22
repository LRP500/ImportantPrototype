using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI.HUD
{
    public abstract class Gauge : Element
    {
        [SerializeField]
        private Image _fill;

        private IDisposable _disposable;
        
        protected abstract IObservable<float> Current { get; }
        protected abstract IObservable<float> Max { get; }
        
        protected override void OnShow()
        {
            _disposable = Current
                .CombineLatest(Max, (current, max) => (current, max))
                .Subscribe(OnValueChanged);
        }

        private void OnValueChanged((float current, float max) value)
        {
            var (current, max) = value;
            _fill.fillAmount = current / max;
        }

        protected override void OnHide()
        {
            _disposable.Dispose();
        }

        public override void Dispose()
        {
            base.Dispose();
            _disposable.Dispose();
        }
    }
}