using System;
using ImportantPrototype.Stats;
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
        
        protected abstract ModifiableStat Health { get; }
        protected abstract ModifiableStat MaxHealth { get; }
        
        protected override void OnShow()
        {
            _disposable = Health.Value
                .Concat(MaxHealth.Value)
                .Subscribe(SetFill);
        }

        protected override void OnHide()
        {
            _disposable.Dispose();
        }

        private void SetFill(float health)
        {
            _fill.fillAmount = Health.Value.Value / MaxHealth.Value.Value;
        }

        public override void Dispose()
        {
            base.Dispose();
            _disposable.Dispose();
        }
    }
}