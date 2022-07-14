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
        private MutationReactiveVariable _selectedMutation;
        
        [SerializeField]
        private MutationListView _mutationList;

        public override void Initialize()
        {
            _mutationList.Bind(_mutationManager.Mutations);
            
            // _rerollModifierButton
            //     .OnClickAsObservable()
            //     .Select(_ => _selectedMutation.Value)
            //     .WhereNotNull()
            //     .Subscribe(OnRerollModifierButtonClicked)
            //     .AddTo(gameObject);
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

        // private void OnRerollModifierButtonClicked(Mutation mutation)
        // {
        //     _mutationManager.RerollModifier(mutation);
        //     _mutationList.Refresh();
        // }
    }
}