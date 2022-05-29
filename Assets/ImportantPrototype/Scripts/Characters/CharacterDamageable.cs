using Extensions;
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
            Health = _character.Stats.Health.Current;
        }

        private void OnEnable()
        {
            OnDeath.TakeFirst()
                .Subscribe(_ => _character.OnDeath())
                .AddToDisable(this);
        }
    }
}