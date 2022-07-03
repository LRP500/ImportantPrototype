using Cinemachine;
using ImportantPrototype.Characters;
using UniRx;
using UnityEngine;

namespace ImportantPrototype.Feel
{
    [RequireComponent(typeof(CinemachineImpulseSource))]
    public class PlayerFiringFeedback : MonoBehaviour
    {
        [SerializeField]
        private PlayerFiring _playerFiring;

        [SerializeField]
        private float _intensity = 0.1f;
        
        private CinemachineImpulseSource _impulse;

        private void Awake()
        {
            _impulse = GetComponent<CinemachineImpulseSource>();

            _playerFiring.OnFire
                .Subscribe(_ => Play())
                .AddTo(gameObject);
        }

        private void Play()
        {
            _impulse.GenerateImpulse(_intensity);
        }
    }
}