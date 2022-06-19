using ImportantPrototype.Mutations;
using UnityEngine;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI
{
    public class LevelUpScreen : Element
    {
        [SerializeField]
        private MutationManager _mutationManager;
        
        [SerializeField]
        private MutationSelection _mutationSelection;

        private void OnMutationSelected(Mutation gene)
        {
            _mutationManager.Pick(gene);
            Hide();
        }

        protected override void OnShow()
        {
            var choices = _mutationManager.GetNextMutationChoices();
            _mutationSelection.Open(choices, OnMutationSelected);
        }
        
        protected override void OnHide()
        {
            _mutationSelection.Clear();
            PauseManager.Resume();
        }
    }
}