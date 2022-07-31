using System;
using ImportantPrototype.Gameplay.Familiars;
using UnityEngine;

namespace ImportantPrototype.Gameplay.Mutations.Genes
{
    [Serializable]
    public class GainFamiliarGene : Gene
    {
        [SerializeField]
        private FamiliarData _familiar;
        
        public override void Apply(GameplayContext context)
        {
            context.FamiliarManager.Add(_familiar);
        }

        public override void Rollback(GameplayContext context)
        {
            context.FamiliarManager.Remove(_familiar);
        }

        public override void Scale(float multiplier)
        {
        }
        
        protected override Gene Copy()
        {
            return (GainFamiliarGene) MemberwiseClone();
        }
    }
}
