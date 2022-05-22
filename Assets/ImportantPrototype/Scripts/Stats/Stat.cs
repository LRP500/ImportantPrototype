using UniRx;

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
        public StatType Type { get; }


        /// <summary>
        /// The stat's current value.
        /// </summary>
        public virtual float Value { get; }
        
        protected Stat(StatType type, float value)
        {
            Type = type;
            Value = value;
        }
    }
}