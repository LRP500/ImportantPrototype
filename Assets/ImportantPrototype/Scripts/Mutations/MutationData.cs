using System.Collections.Generic;
using ImportantPrototype.Mutations.Mods;
using ImportantPrototype.System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace ImportantPrototype.Mutations
{
    [CreateAssetMenu(menuName = ContextMenuPath.Mutations + "Mutation")]
    public class MutationData : SerializedScriptableObject
    {
        [SerializeField]
        [TitleGroup("Info")]
        private string _name;

        [Multiline]
        [SerializeField]
        [TitleGroup("Info")]
        private string _description;

        [OdinSerialize]
        [TitleGroup("Genes")]
        [LabelText("Positive")]
        private List<Gene> _positiveGenes = new ();

        [OdinSerialize]
        [TitleGroup("Genes")]
        [LabelText("Negative")]
        private List<Gene> _negativeGenes = new ();

        [Range(0, 1)]
        [SerializeField]
        [TitleGroup("Genotype Modifier")]
        private float _modChance = 1f;
        
        [SerializeField]
        [ShowIf("@ _modChance != 0")]
        [TitleGroup("Genotype Modifier")]
        private List<GenotypeModData> _genotypeMods = new ();
        
        public string Name => _name;
        public string Description => _description;
        public IEnumerable<Gene> PositiveGenes => _positiveGenes;
        public IEnumerable<Gene> NegativeGenes => _negativeGenes;
        public IEnumerable<GenotypeModData> GenotypeMods => _genotypeMods;
        public float ModChance => _modChance;
    }
}
