using ImportantPrototype.Gameplay.Mutations;
using ImportantPrototype.System;
using UnityEngine;

namespace ImportantPrototype.Tools.Console.Commands
{
    [CreateAssetMenu(menuName = ContextMenuPath.ConsoleCommands + "Recalculate Genotype")]
    public class RecalculateGenotypeCommand : ConsoleCommand
    {
        [SerializeField]
        private MutationManager _mutationManager;
        
        public override bool Execute(string[] args)
        {
            if (_mutationManager == null) return false;
            _mutationManager.RecalculateGenotype();
            return true;
        }
    }
}