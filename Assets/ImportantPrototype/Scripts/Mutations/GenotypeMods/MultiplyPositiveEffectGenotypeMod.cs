using System;
using UnityEngine;

namespace ImportantPrototype.Mutations
{
    [Serializable]
    public class MultiplyPositiveEffectGenotypeMod : GenotypeMod
    {
        [SerializeField]
        private float _multiplier; 
        
        public override string GetDescription()
        {
            return $"Multiply positive genes of the next mutation by {_multiplier}";
        }

        protected override void OnApply(ref Mutation mutation)
        {
            foreach (var gene in mutation.PositiveGenes)
            {
                gene.Scale(_multiplier);
            }
        }
    }
}