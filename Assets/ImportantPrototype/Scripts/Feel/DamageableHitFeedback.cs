using ImportantPrototype.Characters;
using MoreMountains.Feedbacks;
using UniRx;
using UnityEngine;

namespace ImportantPrototype.Feel
{
    public class DamageableHitFeedback : MonoBehaviour
    {
        [SerializeField]
        private MMF_Player _feedback;

        [SerializeField]
        private CharacterDamageable _damageable;

        private void Awake()
        {
            _damageable.OnDamageTaken
                .Subscribe(_ => _feedback.PlayFeedbacks())
                .AddTo(gameObject);
        }
    }
}