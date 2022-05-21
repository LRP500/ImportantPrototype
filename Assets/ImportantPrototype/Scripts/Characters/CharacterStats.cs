using ImportantPrototype.Stats;
using UnityEngine;

namespace ImportantPrototype.Characters
{
    public class CharacterStats : MonoBehaviour
    {
        [SerializeField]
        private StatCollectionData _collectionData;
        
        private StatCollection _stats;

        public ModifiableStat MaxHealth { get; private set; }
        public ModifiableStat Health { get; private set; }
        
        private void Awake()
        {
            _stats = new StatCollection(_collectionData);
            Health = _stats.GetStat("health");
            MaxHealth = _stats.GetStat("max_health");
        }
    }
}