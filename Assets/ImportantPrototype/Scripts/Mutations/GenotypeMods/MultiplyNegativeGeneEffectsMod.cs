namespace ImportantPrototype.Gameplay.Mutations.Mods
{
    public class MultiplyNegativeGeneEffectsMod : MultiplyGeneEffectMod
    {
        public MultiplyNegativeGeneEffectsMod(int duration, float multiplier)
            : base(duration, multiplier)
        { }
        
        public override string GetDescription()
        {
            return $"Multiply negative gene effects by {Multiplier}";
        }

        protected override void OnApply(ref Mutation mutation)
        {
            foreach (var gene in mutation.NegativeGenes)
            {
                gene.Scale(Multiplier);
            }
        }
    }
}