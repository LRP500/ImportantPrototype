using System;
using UniRx;

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
        
        public override void SetValue(float value)
        {
            base.SetValue(value);
            Current.SetValue(value);
        }

        public IObservable<bool> ObserveFull()
        {
            return Current.Property.Select(current => current >= Value);
        }
    }
}