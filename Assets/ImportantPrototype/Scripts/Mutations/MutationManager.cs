using System.Collections.Generic;
using System.Linq;
using ImportantPrototype.Managers;
using ImportantPrototype.Mutations.Mods;
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
        private readonly ReactiveCollection<Mutation> _mutations = new ();

        public IEnumerable<GenotypeMod> GenotypeMods => _genotypeMods;
        public IEnumerable<Mutation> Mutations => _mutations;

        public IEnumerable<Mutation> GetNextMutationChoices()
        {
            return _allMutations.Items
                .Shuffle()
                .Take(_mutationChoiceCount)
                .Select(Mutation.FromData);
        }

        public void Pick(Mutation mutation)
        { 
            ApplyMutation(mutation);
            UpdateGenotypeMods();
        }

        private void ApplyMutation(Mutation mutation)
        {
            ApplyGenotypeMod(ref mutation);
            mutation.OnPick(Context.Player.Value);

            _mutations.Add(mutation);
            _genotypeMods.Add(mutation.GenotypeMod);
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

        private void ApplyGenotypeMod(ref Mutation mutation)
        {
            foreach (var mod in _genotypeMods)
            {
                mod.Apply(ref mutation);
            }
        }

        private void RecalculateGenotype()
        {
            for (int i = 0, length = _mutations.Count; i < length; ++i)
            {
                _mutations[i].Reset();
            }
        }
    }
}