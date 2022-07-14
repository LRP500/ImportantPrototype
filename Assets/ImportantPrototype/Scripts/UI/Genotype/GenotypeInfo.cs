using ImportantPrototype.Input;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.UI;
using UnityTools.Runtime.Variables.Registerers;

namespace ImportantPrototype.UI.Genotype
{
    [RequireComponent(typeof(RegisterReactiveElement))]
    public class GenotypeInfo : CompositeElement
    {
        public override void Initialize()
        {
            PlayerInput.ObserveTab()
                .Subscribe(_ => Toggle())
                .AddTo(gameObject);
        }
        
        protected override void OnShow()
        {
            base.OnShow();
            PauseManager.Pause();
        }

        protected override void OnHide()
        {
            base.OnHide();
            PauseManager.Resume();
        }
    }
}
