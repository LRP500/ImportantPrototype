namespace ImportantPrototype.Gameplay.Mutations.Mods
{
    public class MultiplyPositiveGeneEffectsMod : MultiplyGeneEffectMod
    {
        public MultiplyPositiveGeneEffectsMod(int duration, float multiplier)
            : base(duration, multiplier)
        { }
        
        public override string GetDescription()
        {
            return $"Multiply positive gene effects by {Multiplier}";
        }

        protected override void OnApply(ref Mutation mutation)
        {
            foreach (var gene in mutation.PositiveGenes)
            {
                gene.Scale(Multiplier);
            }
        }
    }
}