using System;
using System.Collections.Generic;
using System.Linq;
using ImportantPrototype.Stats.Modifiers;
using UniRx;

namespace ImportantPrototype.Stats
{
    public class ModifiableStat : Stat
    {
        private readonly FloatReactiveProperty _modifiedValue = new ();
        public IReadOnlyReactiveProperty<float> Property => _modifiedValue;

        private float BaseValue => base.Value;

        public override float Value
        {
            get
            {
                if (!_isDirty) return _modifiedValue.Value;
                _modifiedValue.Value = Calculate();
                _isDirty = false;
                return _modifiedValue.Value;
            }
        }

        private readonly SortedList<int, List<StatModifier>> _modifiers = new ();
        private bool _isDirty;
        
        public ModifiableStat(StatTypeInfo typeInfo, float value) : base(typeInfo, value)
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

        public void AddModifier(float value, StatModifier.Type type)
        {
            AddModifier(new StatModifier(value, type));
        }

        public void AddModifier(StatModifier mod)
        {
            if (!_modifiers.ContainsKey(mod.Priority))
            {
                _modifiers.Add(mod.Priority, new List<StatModifier> { mod });
            }
            else
            {
                _modifiers[mod.Priority].Add(mod);
            }
            
            _modifiedValue.Value = Calculate();
            // _isDirty = true;
        }
        
        public void RemoveModifier()
        {
            // TODO: Add opposite value mod ? Identify mod with id ?
        }

        private float Calculate()
        {
            float finalValue = BaseValue;

            foreach (var (_, value) in _modifiers)
            {
                for (int i = 0, len = value.Count; i < len; ++i)
                {
                    // TODO:
                    // float sum = 0;
                    // float max = 0;
                    var mod = value[i];
                    var target = mod.ModType == StatModifier.Type.TotalPercentage ? finalValue : BaseValue;
                    finalValue += mod.Apply(target);
                }
            }
            
            return (float) Math.Round(finalValue, 4);
        }
    }
}
