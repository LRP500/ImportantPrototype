using ImportantPrototype.Input;
using ImportantPrototype.Mutations;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI.Genotype
{
    public class GenotypeView : CompositeElement
    {
        [SerializeField]
        private MutationManager _mutationManager;
        
        [SerializeField]
        private MutationListView _mutationList;

        public override void Initialize()
        {
            _mutationList.Bind(_mutationManager.Mutations);

            PlayerInput.ObserveTab()
                .Subscribe(_ => Toggle())
                .AddTo(gameObject);
        }

        protected override void OnShow()
        {
            PauseManager.Pause();
        }

        protected override void OnHide()
        {
            PauseManager.Resume();
        }
    }
}