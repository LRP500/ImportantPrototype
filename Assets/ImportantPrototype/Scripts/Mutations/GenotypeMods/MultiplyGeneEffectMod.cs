namespace ImportantPrototype.Gameplay.Mutations.Mods
{
    public abstract class MultiplyGeneEffectMod : GenotypeMod
    {
        public float Multiplier { get; }

        protected MultiplyGeneEffectMod(int duration, float multiplier) 
            : base(duration)
        {
            Multiplier = multiplier;
        }
    }
}