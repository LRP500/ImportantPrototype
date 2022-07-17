using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityTools.Runtime.Extensions;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI.HUD
{
    public abstract class Gauge : Element
    {
        [SerializeField]
        private Image _fill;

        private readonly SerialDisposable _disposable = new();
        
        protected float Current { get; set; }
        protected float Max { get; set; }

        public override void Initialize()
        {
            _disposable.AddTo(gameObject);
        }

        protected override void OnShow()
        {
            _disposable.Disposable = ObserveValueChanged()
                .Subscribe(OnValueChanged);
        }

        protected virtual IObservable<(float, float)> ObserveValueChanged()
        {
            return Observable.Return((Current, Max));
        }

        private void OnValueChanged((float current, float max) value)
        {
            var (current, max) = value;
            _fill.fillAmount = current / max;
        }

        protected override void OnHide()
        {
            _disposable.Clear();
        }

        public override void Dispose()
        {
            base.Dispose();
            _disposable?.Dispose();
        }
    }
}