using Sirenix.Utilities;

namespace ImportantPrototype.Mutations
{
    public class NegateNegativeGene : GenotypeMod
    {
        public override void Apply(ref Mutation mutation)
        {
            var genes = mutation.NegativeGenes;
            if (genes.IsNullOrEmpty()) return;
            genes.RemoveAt(UnityEngine.Random.Range(0, genes.Count));
        }
    }
}