using System;

namespace ImportantPrototype.Gameplay.Mutations.Genes
{
    public abstract class Gene
    {
        protected string Uid { get; private set; }

        protected void Initialize()
        {
            Uid = Guid.NewGuid().ToString("n");
        }

        public Gene Clone()
        {
            var clone = Copy();
            clone.Initialize();
            return clone;
        }
        
        public abstract void Apply(GameplayContext context);
        public abstract void Rollback(GameplayContext context);
        public abstract void Scale(float multiplier);
        protected abstract Gene Copy();
    }
}