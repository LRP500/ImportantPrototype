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

        public IReadOnlyReactiveCollection<GenotypeMod> GenotypeMods => _genotypeMods;
        public IReadOnlyReactiveCollection<Mutation> ActiveMutations => _activeMutations;

        public IEnumerable<Mutation> GetNextMutationChoices()
        {
            return _allMutations.Items.Shuffle().Take(_mutationChoiceCount);
        }

        public void Pick(Mutation mutation)
        { 
            ApplyMutation(mutation);
            UpdateGenotypeMods();
        }

        private void ApplyMutation(Mutation mutation)
        {
            var modifiedMutation = ApplyGenotypeMod(mutation);
            modifiedMutation.OnPick(Context.Player.Value);

            _activeMutations.Add(modifiedMutation);
            _genotypeMods.Add(modifiedMutation.GenotypeMod);
        }
        
        private void UpdateGenotypeMods()
        {
            for (int i = _genotypeMods.Count - 1; i >= 0; i--)
            {
                var mod = _genotypeMods[i];
                if (mod.Duration <= 0)
                {
                    _genotypeMods.Remove(mod);
                }
            }
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