using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ImportantPrototype.Mutations
{
    [Serializable]
    public abstract class GenotypeMod
    {
        [MinValue(1)]
        [SerializeField]
        private int _duration;

        public int Duration => _duration;
        
        public abstract void Apply(ref Mutation mutation);
    }
}