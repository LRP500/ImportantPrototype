using System;
using System.Globalization;
using ImportantPrototype.Characters;
using ImportantPrototype.Stats;
using ImportantPrototype.Stats.Modifiers;
using UnityEngine;
using Attribute = ImportantPrototype.Stats.Attribute;

namespace ImportantPrototype.Gameplay.Mutations.Genes
{
    [Serializable]
    public abstract class AttributeGene<T> : Gene where T : StatInfo
    {
        [SerializeField]
        private T _stat;
        
        [SerializeField]
        private StatModifier.Type _type;

        [SerializeField]
        private float _value;

        public T Stat => _stat;
        public StatModifier.Type Type => _type;
        public float Value => _value;

        protected abstract Attribute GetAttribute(Player player);
        
        public override void Apply(GameplayContext context)
        {
            var player = context.Player.Value;
            GetAttribute(player)?.AddModifier(Value, Type, Uid);
        }

        public override void Rollback(GameplayContext context)
        {
            var player = context.Player.Value;
            GetAttribute(player).RemoveModifier(Uid);
        }
        
        public override void Scale(float multiplier)
        {
            _value *= multiplier;
        }
        
        public override string ToString()
        {
            var value = ((_value >= 0 ? "+" : "") + _value)
                .ToString(CultureInfo.CurrentCulture);
            
            return _type switch
            {
                StatModifier.Type.Flat => $"{_stat.Name} {value}",
                StatModifier.Type.BasePercentage => $"{_stat.Name} {value}%",
                StatModifier.Type.TotalPercentage => $"{_stat.Name} {value}%",
                _ => "Undefined"
            };
        }

        protected override Gene Copy()
        {
            var clone = (AttributeGene<T>) MemberwiseClone();
            clone._stat = _stat;
            return clone;
        }
    }
}