using ImportantPrototype.Characters;
using ImportantPrototype.Stats;
using ImportantPrototype.Stats.Modifiers;
using ImportantPrototype.System;
using UnityEngine;
using UnityTools.Runtime.ECA.Actions;

namespace ImportantPrototype.Actions
{
    [CreateAssetMenu(menuName = ContextMenuPath.Actions + "Modify Player Stat")]
    public class ModifyPlayerStat : ScriptableAction
    {
        [SerializeField]
        private PlayerReactiveVariable _player;

        [Space]
        [SerializeField]
        private CharacterStatTypeInfo _stat;

        [SerializeField]
        private StatModifier.Type _type;

        [SerializeField]
        private float _value;

        private ModifiableStat _playerStat;
        
        protected override bool ExecuteBehaviour()
        {
            _playerStat ??= _player.Value.Stats.Get(_stat);
            _playerStat.AddModifier(_value, _type);
            return true;
        }
    }
}