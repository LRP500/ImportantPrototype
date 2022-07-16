using System;
using ImportantPrototype.Mutations;
using UniRx;
using UnityEngine;

namespace ImportantPrototype.UI
{
    public class LevelUpRerollModButton : ConditionalButton
    {
        [SerializeField]
        private MutationManager _mutationManager;
        
        protected override void SetInteractable(bool interactable)
        {
            gameObject.SetActive(interactable);
        }
        
        protected override IObservable<bool> ObserveCanInteract()
        {
            return _mutationManager.Mutations
                .ObserveCountChanged()
                .StartWith(() => _mutationManager.Mutations.Count)
                .Select(x => x >= 1);
        }
    }
}