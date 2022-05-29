namespace ImportantPrototype.Stats.Factory
{
    public static class StatFactory
    {
        public static Stat Create(StatType type, StatInfo info, float value)
        {
            return type switch
            {
                StatType.Stat => new Stat(info, value),
                StatType.Attribute => new Attribute(info, value),
                StatType.Vital => new Vital(info, value),
                _ => throw new TypeNotHandledFactoryException(nameof(type))
            };
        }
        
        public static Stat Create(StatTypeValuePair entry)
        {
            return Create(entry.Type, entry.Info, entry.Value);
        }
    }
}
