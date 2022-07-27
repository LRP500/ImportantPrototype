using System;
using System.Collections.Generic;
using ImportantPrototype.Stats.Modifiers;
using UniRx;

namespace ImportantPrototype.Stats
{
    /// <summary>
    /// A stat that can be modified by stacking modifiers.
    /// </summary>
    public class Attribute : Stat
    {
        private readonly FloatReactiveProperty _modifiedValue = new ();
        public IReadOnlyReactiveProperty<float> Property => _modifiedValue;

        private float BaseValue => base.Value;

        public override float Value
        {
            get
            {
                if (_isDirty) Refresh();
                return _modifiedValue.Value;
            }
        }

        private readonly SortedList<int, List<StatModifier>> _sortedModifiers = new ();
        private readonly IList<StatModifier> _modifiers = new List<StatModifier>();
        private bool _isDirty;
        
        public Attribute(StatInfo info, float value) : base(info, value)
        {
            _modifiedValue.Value = value;
        }

        public override void SetValue(float value)
        {
            base.SetValue(value);
            ClearModifiers();
            Refresh();
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

        public void AddModifier(float value, StatModifier.Type type, string id)
        {
            AddModifier(new StatModifier(value, type, id));
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
                
                _modifiedValue.Value = Calculate();
                // _isDirty = true;
                
                return;
            }
        }

        private void Refresh()
        {
            _modifiedValue.Value = Calculate();
            _isDirty = false;
        }
        
        private float Calculate()
        {
            float modValue = 0;

            // We iterate over each group of mod sorted by priority
            foreach (var (_, group) in _sortedModifiers)
            {
                if (group.Count == 0)
                    continue;
                
                float sum = 0;
                float max = 0;
                
                // We calculate total mod value for each type of modifier
                for (int i = 0, length = group.Count; i < length; ++i)
                {
                    var mod = group[i];
                    if (mod.Additive)
                    {
                        sum += mod.Value;
                    }
                    else if (mod.Value > max)
                    {
                        max = mod.Value;
                    }
                }

                // We apply mod value to total mod value
                var groupValue = group[0].Additive ? sum : max;
                modValue += group[0].Apply(BaseValue + modValue, groupValue);
            }
            
            return (float) Math.Round(BaseValue + modValue, 4);
        }
        
        private void ClearModifiers()
        {
            _modifiers.Clear();
            _isDirty = true;
        }
    }
}
