using ImportantPrototype.Stats;
using UnityEngine;

namespace ImportantPrototype.Characters
{
    public class CharacterStats : MonoBehaviour
    {
        [SerializeField]
        private StatCollectionData _collectionData;
        
        private StatCollection Collection { get; set; }
        public ModifiableStat MaxHealth { get; private set; }
        public ModifiableStat Health { get; private set; }
        
        private void Awake()
        {
            Collection = new StatCollection(_collectionData);
            Health = Collection.GetStat("health");
            MaxHealth = Collection.GetStat("max_health");
        }

        public ModifiableStat Get(StatType type)
        {
            return Collection.GetStat(type);
        }
    }
}