using UniRx;
using UnityTools.Runtime.Math.Operations;

namespace ImportantPrototype.Stats
{
    public class ModifiableStat : Stat
    {
        private readonly FloatReactiveProperty _modifiedValue = new ();
        public IReadOnlyReactiveProperty<float> Property => _modifiedValue;

        public override float Value => _modifiedValue.Value;
        public float BaseValue => base.Value;
 
        public ModifiableStat(StatType type, float value) : base(type, value)
        {
            _modifiedValue.Value = value;
        }

        public void SetValue(float value)
        {
            _modifiedValue.Value = value;
        }
        
        public void Add(float increment)
        {
            _modifiedValue.Value += increment;
        }

        public void Remove(float decrement)
        {
            _modifiedValue.Value -= decrement;
        }

        public float Modify(NumericalOperator op, float value)
        {
            var newValue = Value.Modify(op, value); 
            SetValue(newValue);
            return newValue;
        }
    }
}
