using System;
using UnityEngine;

namespace ImportantPrototype.Stats
{
    [Serializable]
    public class StatTypeValuePair
    {
        [SerializeField]
        private StatType _type;
        
        [SerializeField]
        private StatInfo _stat;
        
        [SerializeField]
        private float _value;

        public StatType Type => _type;
        public StatInfo Info => _stat;
        public float Value => _value;
    }
}