using ImportantPrototype.Mutations;
using ImportantPrototype.UI.Common.Style;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.UI
{
    public class ListSelectableMutationViewStyleSetter : SelectableStyleSetter
    {
        [SerializeField]
        private MutationReactiveListVariable _selectedMutations;
        
        protected MutationView View { get; private set; }

        protected override void Awake()
        {
            View = GetComponent<MutationView>();
            base.Awake();
        }
        
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