using System.Collections.Generic;
using ImportantPrototype.System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace ImportantPrototype.Mutations
{
    [CreateAssetMenu(menuName = ContextMenuPath.Mutations + "Mutation")]
    public class MutationData : SerializedScriptableObject
    {
        // [EnumToggleButtons]
        // public InfoMessageType SomeEnum;
        
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
        [LabelText("Randomize")]
        [ShowIf("@ _modChance != 0")]
        [TitleGroup("Genotype Modifier")]
        private bool _randomizeMod;
        
        [OdinSerialize]
        [TitleGroup("Genotype Modifier")]
        [ShowIf("@ _modChance != 0 && !_randomizeMod")]
        private GenotypeMod _genotypeMod = new DefaultGenotypeMod();
        
        public string Name => _name;
        public string Description => _description;
        public List<Gene> PositiveGenes => _positiveGenes;
        public List<Gene> NegativeGenes => _negativeGenes;
        public GenotypeMod GenotypeMod => _genotypeMod;
        public bool RandomizeMod => _randomizeMod;
        public float ModChance => _modChance;
    }
}
