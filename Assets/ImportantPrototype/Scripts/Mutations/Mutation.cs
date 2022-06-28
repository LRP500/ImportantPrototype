using System.Collections.Generic;
using ImportantPrototype.Characters;
using ImportantPrototype.System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

// ReSharper disable ConvertToAutoProperty

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
        private List<Gene> _positiveGenes = new ();

        [OdinSerialize]
        private List<Gene> _negativeGenes = new ();
        
        [OdinSerialize]
        private GenotypeMod _genotypeMod = new DefaultGenotypeMod();
        
        public string Name => _name;
        public string Description => _description;
        public GenotypeMod GenotypeMod => _genotypeMod;
        public IList<Gene> PositiveGenes => _positiveGenes;
        public IList<Gene> NegativeGenes => _negativeGenes;
        
        public void OnPick(Player player)
        {
            ApplyGenes(player);
        }

        private void ApplyGenes(Player player)
        {
            var genes = GetAllGenes();
            for (int i = 0; i < genes.Count; i++)
            {
                genes[i].Apply(player);
            }
        }

        public IReadOnlyList<Gene> GetAllGenes()
        {
            var genes = new List<Gene>(_positiveGenes);
            genes.AddRange(_negativeGenes);
            return genes;
        }
    }
}
