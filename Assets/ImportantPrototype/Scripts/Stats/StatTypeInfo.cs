using System;
using UnityEngine;

namespace ImportantPrototype.Stats
{
    public abstract class StatTypeInfo : ScriptableObject
    {
        [SerializeField]
        private string _name;

        [Multiline]
        [SerializeField]
        private string _description;

        public abstract int Id { get; }
    }
    
    public abstract class StatTypeInfo<T> : StatTypeInfo where T : Enum
    {
        [SerializeField]
        private T _id;

        public override int Id => Interpret(_id);

        private static int Interpret(T value)
        {
            return (int) (object) value;
        }
        
        public static implicit operator int(StatTypeInfo<T> source)
        {
            return source.Id;
        }
    }
}