using UniRx;

namespace ImportantPrototype.Stats
{
    /// <summary>
    /// A simple stat.
    /// </summary>
    public class Stat
    {
        /// <summary>
        /// The stat's current value.
        /// </summary>
        private readonly FloatReactiveProperty _value = new ();

        /// <inheritdoc cref="_value"/>
        public virtual IReadOnlyReactiveProperty<float> Value => _value;

        protected Stat(float value)
        {
            _value.Value = value;
        }
    }
}