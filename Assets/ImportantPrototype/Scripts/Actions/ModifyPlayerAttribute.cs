using ImportantPrototype.Characters;
using ImportantPrototype.Stats.Modifiers;
using ImportantPrototype.System;
using UnityEngine;
using UnityTools.Runtime.ECA.Actions;
using Attribute = ImportantPrototype.Stats.Attribute;

namespace ImportantPrototype.Actions
{
    [CreateAssetMenu(menuName = ContextMenuPath.Actions + "Modify Player Attribute")]
    public class ModifyPlayerAttribute : ScriptableAction
    {
        [SerializeField]
        private PlayerReactiveVariable _player;

        [Space]
        [SerializeField]
        private CharacterStatInfo _stat;

        [SerializeField]
        private StatModifier.Type _type;

        [SerializeField]
        private float _value;

        protected override bool ExecuteBehaviour()
        {
            _player.Value.Stats.Collection
                .Get<Attribute>(_stat)
                .AddModifier(_value, _type);

            return true;
        }
    }
}