﻿using Sirenix.Utilities;

namespace ImportantPrototype.Mutations
{
    public class NegateNegativeGene : GenotypeMod
    {
        public override string GetDescription()
        {
            return "Negate any negative genes for the next mutation";
        }

        protected override void OnApply(ref Mutation mutation)
        {
            var genes = mutation.NegativeGenes;
            if (genes.IsNullOrEmpty()) return;
            genes.RemoveAt(UnityEngine.Random.Range(0, genes.Count));
        }
    }
}