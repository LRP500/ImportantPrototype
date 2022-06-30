using System;
using ImportantPrototype.Stats;
using UnityEngine;
using Attribute = ImportantPrototype.Stats.Attribute;

namespace ImportantPrototype.Characters
{
    public class CharacterStats : MonoBehaviour
    {
        public CharacterStatCollection Collection { get; private set; }

        private void Awake()
        {
            var data = GetComponent<Character>()?.Data;
            Collection = CharacterStatCollection.FromCharacterData(data);
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