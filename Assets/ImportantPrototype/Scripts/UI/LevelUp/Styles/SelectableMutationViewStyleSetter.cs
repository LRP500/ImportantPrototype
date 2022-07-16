using ImportantPrototype.Mutations;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.UI
{
    public class SelectableMutationViewStyleSetter : MutationViewStyleSetter
    {
        [SerializeField]
        private MutationReactiveVariable _selectedMutation;
        
        private void OnEnable()
        {
            _selectedMutation.Property
                .Subscribe(_ => Refresh())
                .AddToDisable(this);
        }

        protected override void Refresh()
        {
            if (View.Mutation == null)
            {
                SetNormal();
            }
            else if (_selectedMutation.Value == View.Mutation)
            {
                SetSelected();
            }
            else
            {
                SetNormal();
            }
        }
    }
}