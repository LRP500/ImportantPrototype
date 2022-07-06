using System;
using ImportantPrototype.Characters;

namespace ImportantPrototype.Mutations
{
    public abstract class Gene
    {
        protected string Uid { get; private set; }

        protected void Initialize()
        {
            Uid = Guid.NewGuid().ToString("n");
        }
        
        public abstract Gene Clone();
        public abstract void Apply(Player player);
        public abstract void Rollback(Player player);
        public abstract void Scale(float multiplier);
    }
}