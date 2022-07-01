using System;
using UnityEngine;

namespace ImportantPrototype.Mutations
{
    [Serializable]
    public class MultiplyNegativeEffectGenotypeMod : GenotypeMod
    {
        [SerializeField]
        private float _multiplier; 
        
        public override string GetDescription()
        {
            return $"Multiply negative genes of the next mutation by {_multiplier}";
        }

        protected override void OnApply(ref Mutation mutation)
        {
            foreach (var gene in mutation.NegativeGenes)
            {
                gene.Scale(_multiplier);
            }
        }
    }
}