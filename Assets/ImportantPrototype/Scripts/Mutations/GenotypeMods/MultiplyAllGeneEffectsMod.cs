namespace ImportantPrototype.Mutations.Mods
{
    public class MultiplyAllGeneEffectsMod : MultiplyGeneEffectMod
    {
        public MultiplyAllGeneEffectsMod(int duration, float multiplier)
            : base(duration, multiplier)
        { }

        public override string GetDescription()
        {
            return $"Multiply all gene effects for the next mutation by {Multiplier}";
        }

        protected override void OnApply(ref Mutation mutation)
        {
            foreach (var gene in mutation.GetAllGenes())
            {
                gene.Scale(Multiplier);
            }
        }
    }
}