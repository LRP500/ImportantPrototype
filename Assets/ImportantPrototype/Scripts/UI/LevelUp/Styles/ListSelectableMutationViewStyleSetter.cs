using ImportantPrototype.Mutations;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.UI
{
    public class ListSelectableMutationViewStyleSetter : MutationViewStyleSetter
    {
        [SerializeField]
        private MutationReactiveListVariable _selectedMutations;
        
        private void OnEnable()
        {
            _selectedMutations.Values
                .ObserveAdd()
                .Subscribe(_ => Refresh())
                .AddToDisable(this);
        }

        protected override void Refresh()
        {
            if (View.Mutation == null)
            {
                SetNormal();
            }
            else if (_selectedMutations.Values.Contains(View.Mutation))
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