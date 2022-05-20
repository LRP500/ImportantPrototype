using UniRx;

namespace ImportantPrototype.Stats
{
    /// <summary>
    /// A simple stat.
    /// </summary>
    public class Stat
    {
        /// <summary>
        /// The stat's identifying name.
        /// </summary>
        private string Name { get; }
        
        /// <summary>
        /// The stat's current value.
        /// </summary>
        private readonly FloatReactiveProperty _value = new ();

        /// <inheritdoc cref="_value"/>
        public virtual IReadOnlyReactiveProperty<float> Value => _value;

        protected Stat(string name, float value)
        {
            Name = name;
            _value.Value = value;
        }
    }
}