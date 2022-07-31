namespace ImportantPrototype.Gameplay.Mutations.Mods
{
    public abstract class GenotypeMod
    {
        public int InitialDuration { get; }
        public int Duration { get; private set; }

        protected GenotypeMod(int duration)
        {
            InitialDuration = duration;
            Duration = duration;
        }
        
        public void Apply(ref Mutation mutation)
        {
            Duration -= 1;
            OnApply(ref mutation);
        }

        public void Reset()
        {
            Duration = InitialDuration;
        }
        
        public abstract string GetDescription();
        protected abstract void OnApply(ref Mutation mutation);
    }
}