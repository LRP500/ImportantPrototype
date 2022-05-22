﻿using UniRx;

namespace ImportantPrototype.Stats
{
    public class ModifiableStat : Stat
    {
        private readonly FloatReactiveProperty _modifiedValue = new ();
        
        public IReadOnlyReactiveProperty<float> BaseValue => base.Value;
        public override IReadOnlyReactiveProperty<float> Value => _modifiedValue;
        
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
    }
}
