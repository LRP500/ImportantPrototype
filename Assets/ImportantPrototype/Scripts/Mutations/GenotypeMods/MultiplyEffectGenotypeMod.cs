using System;
using UnityEngine;

namespace ImportantPrototype.Mutations
{
    [Serializable]
    public class MultiplyEffectGenotypeMod : GenotypeMod
    {
        [SerializeField]
        private float _multiplier; 
        
        public override string GetDescription()
        {
            return $"Multiply all genes of the next mutation by {_multiplier}";
        }

        protected override void OnApply(ref Mutation mutation)
        {
            foreach (var gene in mutation.GetAllGenes())
            {
                gene.Scale(_multiplier);
            }
        }
    }
}