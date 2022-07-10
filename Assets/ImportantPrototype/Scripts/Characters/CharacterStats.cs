using System;
using ImportantPrototype.Stats;
using UniRx;
using UnityEngine;
using Attribute = ImportantPrototype.Stats.Attribute;

namespace ImportantPrototype.Characters
{
    public class CharacterStats : MonoBehaviour
    {
        private Character Character { get; set; }
        public CharacterStatCollection Collection { get; private set; }
        
        private void Awake()
        {
            Character = GetComponent<Character>();
            Collection = CharacterStatCollection.FromCharacterData(Character.Data);
        }

        private void Start()
        {
            Get<Attribute>(CharacterStatType.MovementSpeed).Property
                .Subscribe(Character.Motor.SetSpeed)
                .AddTo(gameObject);
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
        
        public bool IsFullHealth()
        {
            var health = Get<Vital>(CharacterStatType.Health);
            return health.Current.Value < health.Value;
        }
    }
}