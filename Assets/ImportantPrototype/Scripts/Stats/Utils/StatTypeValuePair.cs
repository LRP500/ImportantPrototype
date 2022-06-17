using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ImportantPrototype.Stats
{
    [Serializable]
    public class StatTypeValuePair
    {
        [HideLabel]
        [SerializeField]
        [HorizontalGroup]
        private StatInfo _stat;
        
        [HideLabel]
        [SerializeField]
        [HorizontalGroup(MaxWidth = 100)]
        private float _value;

        public StatInfo Info => _stat;
        public float Value => _value;

        public StatTypeValuePair() { }
        
        public StatTypeValuePair(StatInfo info)
        {
            _stat = info;
        }
    }
}