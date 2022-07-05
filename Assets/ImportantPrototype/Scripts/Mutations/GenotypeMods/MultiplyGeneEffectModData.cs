using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ImportantPrototype.Mutations.Mods
{
    public abstract class MultiplyGeneEffectModData : GenotypeModData
    {
        [SerializeField]
        private bool _randomize;

        [SerializeField]
        [ShowIf(nameof(_randomize))]
        private float _min;

        [SerializeField]
        [ShowIf(nameof(_randomize))]
        private float _max;

        [SerializeField]
        [HideIf(nameof(_randomize))]
        private float _value;

        /// <summary>
        /// Returns calculated value rounded to 1 decimal place.
        /// </summary>
        /// <returns></returns>
        protected float GetValue()
        {
            var value = _randomize ? Random.Range(_min, _max) : _value; 
            return Mathf.Ceil(value * 10f) * 0.1f;
        }
    }
}