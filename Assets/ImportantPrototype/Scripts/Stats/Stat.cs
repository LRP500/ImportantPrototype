namespace ImportantPrototype.Stats
{
    /// <summary>
    /// A simple stat.
    /// </summary>
    public class Stat
    {
        /// <summary>
        /// The stat's type info.
        /// </summary>
        public StatTypeInfo TypeInfo { get; }

        /// <summary>
        /// The stat's current value.
        /// </summary>
        public virtual float Value { get; }
        
        protected Stat(StatTypeInfo typeInfo, float value)
        {
            TypeInfo = typeInfo;
            Value = value;
        }
    }
}