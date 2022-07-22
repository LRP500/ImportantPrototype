using ImportantPrototype.Gameplay;
using UnityEngine;

namespace ImportantPrototype.Damageables.Effects.Audio
{
    public class PlayAudioOnDeath : DeathEffect
    {
        [SerializeField]
        private AK.Wwise.Event _event;
        
        protected override void Trigger()
        {
            _event.Post(gameObject);
        }
    }
}