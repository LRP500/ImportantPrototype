using ImportantPrototype.Mutations;
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

        [SerializeField]
        private MutationReactiveVariable _hoveredMutation;
        
        public override void Initialize()
        {
            _mutationList.Bind(_mutationManager.Mutations);
        }

        protected override void OnShow()
        {
            base.OnShow();
            SelectFirst();
        }

        private void SelectFirst()
        {
            if (_mutationManager.Mutations.Count == 0)
            {
                _hoveredMutation.Clear();
                return;
            }

            _hoveredMutation.SetValue(_mutationManager.Mutations[0]);
        }
    }
}