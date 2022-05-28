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

        private float Value { get; }
        public Type ModType { get; }
        public int Priority { get; }

        public StatModifier(float value, Type type)
        {
            Value = value;
            ModType = type;
            Priority = CalculatePriority();
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

        public float Apply(float statValue)
        {
            return ModType switch
            {
                Type.Flat => Value,
                Type.BasePercentage => statValue * Value / 100,
                Type.TotalPercentage => statValue * Value / 100,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
