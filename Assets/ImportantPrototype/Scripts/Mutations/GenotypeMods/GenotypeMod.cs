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

        public void Apply(ref Mutation mutation)
        {
            _duration -= 1;
            OnApply(ref mutation);
        }

        public abstract string GetDescription();
        protected abstract void OnApply(ref Mutation mutation);
    }
}