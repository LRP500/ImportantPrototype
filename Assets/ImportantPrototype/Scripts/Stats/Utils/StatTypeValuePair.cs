using System;
using UnityEngine;

namespace ImportantPrototype.Stats
{
    [Serializable]
    public class StatTypeValuePair
    {
        [SerializeField]
        private StatTypeInfo _stat;
        
        [SerializeField]
        private float _value;

        public StatTypeInfo Stat => _stat;
        public float Value => _value;
    }
}