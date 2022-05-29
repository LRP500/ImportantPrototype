using ImportantPrototype.Characters;
using ImportantPrototype.Stats;
using ImportantPrototype.Stats.Modifiers;
using ImportantPrototype.System;
using UnityEngine;
using UnityTools.Runtime.ECA.Actions;

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

        private Attribute _playerStat;
        
        protected override bool ExecuteBehaviour()
        {
            var stats = _player.Value.Stats.Collection;
            _playerStat ??= stats.Get<Attribute>(_stat);
            _playerStat.AddModifier(_value, _type);
            return true;
        }
    }
}