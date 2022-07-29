using System;
using UniRx;

namespace ImportantPrototype.Stats
{
    /// <summary>
    /// An attribute fluctuating between min and max.
    /// Both current value and max value can be modified.
    /// </summary>
    public class Vital : Attribute, IDisposable
    {
        public Attribute Current { get; }

        private readonly IDisposable _maxValueChanged;
        
        public Vital(StatInfo info, float value) : base(info, value)
        {
            Current = new Attribute(info, value);
            
            _maxValueChanged = Property
                .SkipLatestValueOnSubscribe()
                .Subscribe(OnMaxValueChanged);
        }

        private void OnMaxValueChanged(float maxValue)
        {
            if (maxValue < Current.Value)
            {
                Current.SetValue(maxValue);
            }
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

        public void Dispose()
        {
            _maxValueChanged?.Dispose();
        }
    }
}