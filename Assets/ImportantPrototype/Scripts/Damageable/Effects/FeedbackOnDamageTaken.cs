using ImportantPrototype.Gameplay;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace ImportantPrototype.Scripts.Damageable.Effects
{
    public class FeedbackOnDamageTaken : DamageTakenEffect
    {
        [SerializeField]
        private MMF_Player _feedback;
        
        protected override void Trigger()
        {
            _feedback.PlayFeedbacks();
        }
    }
}