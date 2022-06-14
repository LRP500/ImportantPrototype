using System.Collections.Generic;
using System.Linq;
using ImportantPrototype.Content;
using ImportantPrototype.Mutations;
using UnityEngine;
using UnityTools.Runtime.Extensions;
using UnityTools.Runtime.UI;
using UnityTools.Runtime.Variables;

namespace ImportantPrototype.UI
{
    public class LevelUpScreen : Element
    {
        [SerializeField]
        private MutationSelection _mutationSelection;

        [SerializeField]
        private IntVariable _mutationChoiceCount;
        
        private void OnMutationSelected(Mutation mutation)
        {
            Hide();
            PauseManager.Resume();
        }

        protected override void OnShow()
        {
            var choices = GetMutationChoices();
            _mutationSelection.Open(choices, OnMutationSelected);
        }

        private IEnumerable<Mutation> GetMutationChoices()
        {
            return GameContent.Instance.Mutations.Shuffle()
                .Take(_mutationChoiceCount);
        }
        
        protected override void OnHide()
        {
            _mutationSelection.Clear();
        }
    }
}