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

        private readonly ReactiveCollection<GenotypeMod> _genotypeMods = new ();
        private readonly ReactiveCollection<Mutation> _activeMutations = new ();

        public IEnumerable<Mutation> GetNextMutationChoices()
        {
            return _allMutations.Items.Shuffle().Take(_mutationChoiceCount);
        }

        public void Pick(Mutation mutation)
        {
            var modifiedMutation = ApplyGenotypeMod(mutation);
            modifiedMutation.OnPick(Context.Player.Value);

            if (modifiedMutation.GenotypeMod != null)
            {
                _genotypeMods.Add(modifiedMutation.GenotypeMod);
            }

            _activeMutations.Add(modifiedMutation);
        }

        private Mutation ApplyGenotypeMod(Mutation mutation)
        {
            var instance = Instantiate(mutation);
            foreach (var mod in _genotypeMods)
            {
                mod.Apply(ref instance);
            }
            return instance;
        }
    }
}