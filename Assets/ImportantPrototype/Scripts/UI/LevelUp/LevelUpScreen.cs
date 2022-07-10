using ImportantPrototype.Mutations;
using UnityEngine;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI
{
    public class LevelUpScreen : CompositeElement
    {
        [SerializeField]
        private MutationManager _mutationManager;

        [SerializeField]
        private MutationReactiveListVariable _mutationChoices;
        
        [SerializeField]
        private MutationSelection _mutationSelection;

        private void OnMutationSelected(Mutation mutation)
        {
            _mutationManager.Pick(mutation);
            Hide();
        }
        
        protected override void OnShow()
        {
            var choices = _mutationChoices.Values;
            _mutationSelection.Open(choices, OnMutationSelected);
        }

        protected override void OnHide()
        {
            PauseManager.Resume();
        }
    }
}