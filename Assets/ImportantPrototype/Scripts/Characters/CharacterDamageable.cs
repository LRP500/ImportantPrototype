using ImportantPrototype.Stats;
using UniRx;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.Characters
{
    public class CharacterDamageable : Damageable
    {
        private Character _character;

        private void Awake()
        {
            _character = GetComponent<Character>();
        }

        private void Start()
        {
            Health = _character.Stats.Get<Vital>(CharacterStatType.Health).Current;
        }

        private void OnEnable()
        {
            OnDeath
                .TakeFirst()
                .Subscribe(_ => _character.OnDeath())
                .AddToDisable(this);
        }
    }
}