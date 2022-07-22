using ImportantPrototype.Gameplay;
using UniRx;
using UnityEngine;

namespace ImportantPrototype.Damageables.Effects
{
    [RequireComponent(typeof(IDamageable))]
    public abstract class DeathEffect : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<IDamageable>().OnDeath
                .Subscribe(_ => Trigger())
                .AddTo(gameObject);
        }

        protected abstract void Trigger();
    }
}