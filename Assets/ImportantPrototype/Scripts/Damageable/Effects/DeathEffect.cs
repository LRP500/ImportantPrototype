using UniRx;
using UnityEngine;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.Gameplay
{
    [RequireComponent(typeof(IDamageable))]
    public abstract class DeathEffect : MonoBehaviour
    {
        private void OnEnable()
        {
            GetComponent<IDamageable>().OnDeath
                .TakeFirst()
                .Subscribe(_ => Trigger())
                .AddToDisable(this);
        }

        protected abstract void Trigger();
    }
}