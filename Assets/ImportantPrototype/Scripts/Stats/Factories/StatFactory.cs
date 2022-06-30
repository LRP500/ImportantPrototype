namespace ImportantPrototype.Stats.Factory
{
    public static class StatFactory
    {
        public static Stat Create(StatInfo info, float value)
        {
            return info.Type switch
            {
                StatType.Stat => new Stat(info, value),
                StatType.Attribute => new Attribute(info, value),
                StatType.Vital => new Vital(info, value),
                _ => throw new TypeNotHandledFactoryException(nameof(info.Type))
            };
        }
        
        public static Stat Create(StatTypeValuePair entry)
        {
            return Create(entry.Info, entry.Value);
        }
    }
}
