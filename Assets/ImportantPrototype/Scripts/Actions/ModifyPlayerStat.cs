﻿using ImportantPrototype.Characters;
using ImportantPrototype.Stats;
using ImportantPrototype.System;
using UnityEngine;
using UnityTools.Runtime.ECA.Actions;
using UnityTools.Runtime.Math.Operations;

namespace ImportantPrototype.Actions
{
    [CreateAssetMenu(menuName = ContextMenuPath.Actions + "Modify Player Stat")]
    public class ModifyPlayerStat : ScriptableAction
    {
        [SerializeField]
        private PlayerReactiveVariable _player;

        [Space]
        [SerializeField]
        private StatType _stat;

        [SerializeField]
        private NumericalOperator _operator;

        [SerializeField]
        private float _value;

        private ModifiableStat _playerStat;
        
        protected override bool ExecuteBehaviour()
        {
            _playerStat ??= _player.Property.Value.Stats.Get(_stat);
            var newValue = _playerStat.Value.Value.Modify(_operator, _value);
            _playerStat.SetValue(newValue);
            return true;
        }
    }
}