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
        private MutationSelection _mutationSelection;

        private void OnMutationSelected(Mutation mutation)
        {
            _mutationManager.Pick(mutation);
            Hide();
        }
        
        protected override void OnShow()
        {
            _mutationSelection.Open(OnMutationSelected);
        }

        protected override void OnHide()
        {
            PauseManager.Resume();
        }
    }
}