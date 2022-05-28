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

        private readonly SortedList<int, List<StatModifier>> _sortedModifiers = new ();
        private readonly IList<StatModifier> _modifiers = new List<StatModifier>();
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

        private void AddModifier(StatModifier mod)
        {
            if (!_sortedModifiers.ContainsKey(mod.Priority))
            {
                _sortedModifiers.Add(mod.Priority, new List<StatModifier> { mod });
            }
            else
            {
                _sortedModifiers[mod.Priority].Add(mod);
            }
            
            _modifiers.Add(mod);
            _modifiedValue.Value = Calculate();
            // _isDirty = true;
        }
        
        public void RemoveModifier(string id)
        {
            for (int i = 0, length = _modifiers.Count; i < length; ++i)
            {
                var mod = _modifiers[i];
                if (!mod.Id.Equals(id)) continue;
                _sortedModifiers[mod.Priority].Remove(mod);
                _modifiers.Remove(mod);
                // _isDirty = true;
                return;
            }
        }

        private float Calculate()
        {
            float finalValue = BaseValue;

            foreach (var (_, value) in _sortedModifiers)
            {
                for (int i = 0, length = value.Count; i < length; ++i)
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
