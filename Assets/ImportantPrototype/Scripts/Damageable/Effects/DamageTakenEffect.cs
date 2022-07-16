using UniRx;
using UnityEngine;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.Gameplay
{
    [RequireComponent(typeof(IDamageable))]
    public abstract class DamageTakenEffect : MonoBehaviour
    {
        private void OnEnable()
        {
            GetComponent<IDamageable>().OnDamageTaken
                .TakeFirst()
                .Subscribe(_ => Trigger())
                .AddToDisable(this);
        }

        protected abstract void Trigger();
    }
}