using System;
using System.Collections.Generic;
using ImportantPrototype.System;
using UnityEngine;

namespace ImportantPrototype.Stats
{
    [CreateAssetMenu(menuName = ContextMenuPath.Stats + "Stat Collection")]
    public class StatCollectionData : ScriptableObject
    {
        [Serializable]
        public class StatTypeValuePair
        {
            public StatType type;
            public float value;
        }

        [SerializeField]
        private List<StatTypeValuePair> _stats;

        public IEnumerable<StatTypeValuePair> Stats => _stats;
    }
}