using UniRx;
using UnityEngine;

namespace ImportantPrototype.Gameplay
{
    [RequireComponent(typeof(IDamageable))]
    public abstract class DamageTakenEffect : MonoBehaviour
    {
        protected virtual void Awake()
        {
            GetComponent<IDamageable>().OnDamageTaken
                .Subscribe(_ => Trigger())
                .AddTo(this);
        }

        protected abstract void Trigger();
    }
}