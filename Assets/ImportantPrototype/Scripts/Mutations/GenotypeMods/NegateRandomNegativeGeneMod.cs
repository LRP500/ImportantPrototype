using Sirenix.Utilities;

namespace ImportantPrototype.Mutations.Mods
{
    public class NegateRandomNegativeGeneMod : GenotypeMod
    {
        public NegateRandomNegativeGeneMod(int duration)
            : base(duration)
        { }

        public override string GetDescription()
        {
            return "Negate random negative gene effects";
        }

        protected override void OnApply(ref Mutation mutation)
        {
            var genes = mutation.NegativeGenes;
            if (genes.IsNullOrEmpty()) return;
            genes.RemoveAt(UnityEngine.Random.Range(0, genes.Count));
        }
    }
}