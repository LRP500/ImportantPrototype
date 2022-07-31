using ImportantPrototype.Gameplay.Mutations;
using ImportantPrototype.UI.Common.Style;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.UI
{
    [RequireComponent(typeof(MutationView))]
    public class MutationViewStyleSetter : SelectableStyleSetter
    {
        [SerializeField]
        private MutationReactiveVariable _selectedMutation;
        
        protected MutationView View { get; private set; }

        protected override void Awake()
        {
            View = GetComponent<MutationView>();
            base.Awake();
        }
        
        private void OnEnable()
        {
            if (_selectedMutation == null) return;
            
            _selectedMutation.Property
                .Subscribe(_ => Refresh())
                .AddToDisable(this);
        }

        protected override void Refresh()
        {
            if (_selectedMutation == null || View.Mutation == null)
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