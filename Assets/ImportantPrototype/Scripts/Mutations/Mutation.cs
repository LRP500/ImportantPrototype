using System.Collections.Generic;
using ImportantPrototype.Characters;
using ImportantPrototype.System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace ImportantPrototype.Mutations
{
    [CreateAssetMenu(menuName = ContextMenuPath.Mutations + "Mutation")]
    public class Mutation : SerializedScriptableObject
    {
        [SerializeField]
        private string _name;

        [Multiline]
        [SerializeField]
        private string _description;

        [OdinSerialize]
        private List<Gene> _genes = new ();
        
        public string Name => _name;
        public string Description => _description;
        public IReadOnlyList<Gene> Genes => _genes;

        public void OnPick(Player player)
        {
            ApplyGenes(player);
        }

        private void ApplyGenes(Player player)
        {
            for (int i = 0; i < _genes.Count; i++)
            {
                _genes[i].Apply(player);
            }
        }
    }
}
