using Sirenix.OdinInspector;
using UnityEngine;

namespace ImportantPrototype.Mutations.Mods
{
    public abstract class GenotypeModData : ScriptableObject
    {
        [ReadOnly]
        [MinValue(1)]
        [SerializeField]
        private int _duration = 1;

        protected int Duration => _duration;
        
        public abstract GenotypeMod Create();
    }
}