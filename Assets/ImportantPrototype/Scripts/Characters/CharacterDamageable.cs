using ImportantPrototype.Gameplay;
using ImportantPrototype.Stats;
using UniRx;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.Characters
{
    public class CharacterDamageable : Damageable
    {
        private Character _character;
        private Attribute _characterHealth;

        public override double Health => _characterHealth.Value;
        
        private void Awake()
        {
            _character = GetComponent<Character>();
        }

        private void Start()
        {
            _characterHealth = _character.Stats.Get<Vital>(CharacterStatType.Health).Current;
        }

        private void OnEnable()
        {
            OnDeath.TakeFirst()
                .Subscribe(_ => _character.OnDeath())
                .AddToDisable(this);
        }
        
        protected override void ApplyDamage(float damage)
        {
            _characterHealth.Remove(damage);
        }
    }
}