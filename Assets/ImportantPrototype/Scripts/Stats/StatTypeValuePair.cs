using System;
using UnityEngine;

namespace ImportantPrototype.Stats
{
    [Serializable]
    public class StatTypeValuePair
    {
        [SerializeField]
        private StatType _stat;
        
        [SerializeField]
        private float _value;

        public StatType Stat => _stat;
        public float Value => _value;
    }
}