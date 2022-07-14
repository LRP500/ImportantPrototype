using ImportantPrototype.Input;
using ImportantPrototype.Mutations;
using ImportantPrototype.UI.LevelUp;
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

        [SerializeField]
        private LevelUpRerollModView _rerollModView;

        [SerializeField]
        private LevelUpSwapMutationView _swapMutationsView;
        
        private void OnMutationSelected(Mutation mutation)
        {
            _mutationManager.Pick(mutation);
            Hide();
        }

        protected override void OnShow()
        {
            PlayerInput.Map = PlayerInput.InputMap.Menu;
            _mutationSelection.Open(OnMutationSelected);
            _swapMutationsView.Hide();
            _rerollModView.Hide();
        }

        protected override void OnHide()
        {
            PauseManager.Resume();
            PlayerInput.Map = PlayerInput.InputMap.Gameplay;
        }
    }
}