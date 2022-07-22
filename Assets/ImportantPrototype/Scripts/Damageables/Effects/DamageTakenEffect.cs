using ImportantPrototype.Gameplay;
using UniRx;
using UnityEngine;

namespace ImportantPrototype.Damageables.Effects
{
    [RequireComponent(typeof(IDamageable))]
    public abstract class DamageTakenEffect : MonoBehaviour
    {
        protected virtual void Awake()
        {
            GetComponent<IDamageable>().OnDamageTaken
                .Subscribe(_ => Trigger())
                .AddTo(gameObject);
        }

        protected abstract void Trigger();
    }
}