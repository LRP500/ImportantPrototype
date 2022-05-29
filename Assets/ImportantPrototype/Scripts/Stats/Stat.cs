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
        public StatInfo Info { get; }

        /// <summary>
        /// The stat's current value.
        /// </summary>
        public virtual float Value { get; }

        public Stat(StatInfo info, float value)
        {
            Info = info;
            Value = value;
        }
    }
}