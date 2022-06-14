using System.Collections.Generic;
using System.Linq;
using ImportantPrototype.Managers;
using ImportantPrototype.System;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.Extensions;
using UnityTools.Runtime.Variables;

namespace ImportantPrototype.Mutations
{
    [CreateAssetMenu(menuName = ContextMenuPath.Managers + "Mutation Manager")]
    public class MutationManager : ScriptableManager
    {
        [SerializeField]
        private MutationAssetListVariable _allMutations;
        
        [SerializeField]
        private IntVariable _mutationChoiceCount;

        private readonly ReactiveCollection<Mutation> _activeMutations = new ();

        public IEnumerable<Mutation> GetNextMutationChoices()
        {
            return _allMutations.Items.Shuffle().Take(_mutationChoiceCount);
        }

        public void Pick(Mutation mutation)
        {
            mutation.OnPick(Context.Player.Value);
            _activeMutations.Add(mutation);
        }
    }
}