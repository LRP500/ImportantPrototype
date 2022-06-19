using ImportantPrototype.Characters;
using ImportantPrototype.Stats;
using ImportantPrototype.Stats.Modifiers;
using ImportantPrototype.System;
using ImportantPrototype.Weapons;
using UnityEngine;

namespace ImportantPrototype.Mutations
{
    [CreateAssetMenu(menuName = ContextMenuPath.Mutations + "Weapon Attribute")]
    public class WeaponAttributeMutation : Mutation
    {
        [SerializeField]
        private WeaponStatType _stat;

        [SerializeField]
        private StatModifier.Type _type;

        [SerializeField]
        private float _value;

        public override void OnPick(Player player)
        {
            player.WeaponHolder.Weapon.Value.Stats
                .Get<Attribute>((int) _stat)
                .AddModifier(_value, _type);
        }
    }
}