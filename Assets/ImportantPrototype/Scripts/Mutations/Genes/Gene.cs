using ImportantPrototype.Characters;

namespace ImportantPrototype.Mutations
{
    public abstract class Gene
    {
        public abstract Gene Clone();
        public abstract void Apply(Player player);
        public abstract void Scale(float multiplier);
    }
}