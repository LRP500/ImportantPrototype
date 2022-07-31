using System;
using ImportantPrototype.Characters;
using Attribute = ImportantPrototype.Stats.Attribute;

namespace ImportantPrototype.Gameplay.Mutations.Genes
{
    [Serializable]
    public class PlayerAttributeGene : AttributeGene<CharacterStatInfo>
    {
        protected override Attribute GetAttribute(Player player)
        {
            return player.Stats.Collection.Get<Attribute>(Stat);
        }
    }
}