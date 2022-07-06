using System;

namespace ImportantPrototype.Stats.Modifiers
{
    public class StatModifier
    {
        public enum Type
        {
            Flat = 0,
            BasePercentage = 1,
            TotalPercentage = 2
        }

        public string Id { get; }
        public bool Additive { get; }
        public float Value { get; }
        public int Priority { get; }
        private Type ModType { get; }

        public StatModifier(float value, Type type)
        {
            Value = value;
            ModType = type;
            Additive = true;
            Priority = CalculatePriority();
        }

        public StatModifier(float value, Type type, string id)
            : this(value, type)
        {
            Id = id;
        }
        
        private StatModifier(float value, Type type, string id, bool additive) 
            : this(value, type, id)
        {
            Additive = additive;
        }
        
        private int CalculatePriority()
        {
            return ModType switch
            {
                Type.Flat => 100,
                Type.BasePercentage => 200,
                Type.TotalPercentage => 300,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        /// <summary>
        /// Returns the result of this modifier with value <paramref name="modValue"/>
        /// applied to stat of base value <paramref name="statBaseValue"/>
        /// and returns the result.
        /// </summary>
        /// <param name="statBaseValue">the base value of the stat to apply mod to</param>
        /// <param name="modValue">The value of the mod to apply to stat</param>
        /// <returns></returns>
        public float Apply(float statBaseValue, float modValue)
        {
            return ModType switch
            {
                Type.Flat => modValue,
                Type.BasePercentage => statBaseValue * modValue / 100,
                Type.TotalPercentage => statBaseValue * modValue / 100,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
