using ImportantPrototype.Characters;
using ImportantPrototype.Stats;
using ImportantPrototype.Stats.Modifiers;
using ImportantPrototype.System;
using UnityEngine;

namespace ImportantPrototype.Mutations
{
    [CreateAssetMenu(menuName = ContextMenuPath.Mutations + "Player Attribute")]
    public class PlayerAttributeMutation : Mutation
    {
        [SerializeField]
        private CharacterStatType _stat;

        [SerializeField]
        private StatModifier.Type _type;

        [SerializeField]
        private float _value;

        public override void OnPick(Player player)
        {
            player.Stats.Collection
                .Get<Attribute>((int) _stat)
                .AddModifier(_value, _type);
        }
    }
}