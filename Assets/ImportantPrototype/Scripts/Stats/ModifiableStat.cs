using UniRx;

namespace ImportantPrototype.Stats
{
    public class ModifiableStat : Stat
    {
        private readonly FloatReactiveProperty _modifiedValue = new ();
        
        public IReadOnlyReactiveProperty<float> BaseValue => base.Value;
        public override IReadOnlyReactiveProperty<float> Value => _modifiedValue;
        
        public ModifiableStat(string name, float value) : base(name, value)
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
