using System;
using ImportantPrototype.Characters;
using ImportantPrototype.Weapons;
using Attribute = ImportantPrototype.Stats.Attribute;

namespace ImportantPrototype.Gameplay.Mutations.Genes
{
    [Serializable]
    public class WeaponAttributeGene : AttributeGene<WeaponStatInfo>
    {
        protected override Attribute GetAttribute(Player player)
        {
            var weapon = player.Weapon.Value;
            return weapon.Stats.Get<Attribute>(Stat);
        }
    }
}