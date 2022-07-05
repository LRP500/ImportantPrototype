namespace ImportantPrototype.Mutations.Mods
{
    public abstract class GenotypeMod
    {
        public int Duration { get; private set; }

        protected GenotypeMod(int duration)
        {
            Duration = duration;
        }
        
        public void Apply(ref Mutation mutation)
        {
            Duration -= 1;
            OnApply(ref mutation);
        }

        public abstract string GetDescription();
        protected abstract void OnApply(ref Mutation mutation);
    }
}