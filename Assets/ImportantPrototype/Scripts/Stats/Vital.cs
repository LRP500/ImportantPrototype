namespace ImportantPrototype.Stats
{
    /// <summary>
    /// An attribute fluctuating between min and max.
    /// Both current value and max value can be modified.
    /// </summary>
    public class Vital : Attribute
    {
        public Attribute Current { get; }

        public Vital(StatInfo info, float value) : base(info, value)
        {
            Current = new Attribute(info, value);
        }
    }
}