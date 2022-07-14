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

        public override void Initialize()
        {
            _mutationList.Bind(_mutationManager.Mutations);
        }
    }
}