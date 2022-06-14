using System;
using ImportantPrototype.Stats;
using UnityEngine;
using Attribute = ImportantPrototype.Stats.Attribute;

namespace ImportantPrototype.Characters
{
    public class CharacterStats : MonoBehaviour
    {
        [SerializeField]
        private StatCollectionData _collectionData;

        public StatCollection Collection { get; private set; }
        public Vital Health { get; private set; }
        
        private void Awake()
        {
            Collection = new CharacterStatCollection(_collectionData);
            Health = Collection.Get<Vital>((int) CharacterStatType.Health);
        }

        public T Get<T>(CharacterStatType id) where T : Stat
        {
            return Collection.Get<T>((int) id);
        }

        public IObservable<float> ObserveVital(CharacterStatType type)
        {
            return Collection.Get<Vital>((int) type).Current.Property;
        }
        
        public IObservable<float> ObserveAttribute(CharacterStatType type)
        {
            return Collection.Get<Attribute>((int) type).Property;
        }
    }
}