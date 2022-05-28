using System;
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
            Health = Collection.GetStat((int) CharacterStatType.Health);
            MaxHealth = Collection.GetStat((int) CharacterStatType.MaxHealth);
        }

        public ModifiableStat Get(StatTypeInfo typeInfo)
        {
            return Collection.GetStat(typeInfo.Id);
        }

        public ModifiableStat Get(CharacterStatType type)
        {
            return Collection.GetStat((int) type);
        }
        
        public IObservable<float> ObserveValueChanged(CharacterStatType type)
        {
            return Get(type).Property;
        }
    }
}