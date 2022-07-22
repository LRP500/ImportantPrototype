using Cinemachine;
using DG.Tweening;
using Sirenix.OdinInspector;
using UniRx;
using UniRx.Triggers;
using UnityEditor;
using UnityEngine;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.Damageables.Effects
{
    public class Explosion : MonoBehaviour
    {
        [MinValue(0)]
        [SerializeField]
        private float _radius = 1;

        [SerializeField]
        private float _fadeDuration = 1f;
        
        [SerializeField]
        private CircleCollider2D _collider;

        [SerializeField]
        private SpriteRenderer _renderer;

        [SerializeField]
        private CinemachineImpulseSource _impulseSource;
        
        private void Awake()
        {
            _collider.enabled = false;
            _renderer.enabled = false;
        }

        public void Trigger()
        {
            this.FixedUpdateAsObservable()
                .Skip(1)
                .TakeFirst()
                .DoOnSubscribe(OnExplosionStart)
                .Subscribe(_ =>
                {
                    OnExplosionEnd();
                })
                .AddTo(gameObject);
        }

        private void OnExplosionStart()
        {
            _impulseSource.GenerateImpulse();
            _collider.enabled = true;
            _renderer.enabled = true;
        }

        private void OnExplosionEnd()
        {
            _collider.enabled = false;
            _renderer.DOFade(0, _fadeDuration);
        }

        private void UpdateProperties()
        {
            _collider.radius = _radius;
            _renderer.transform.localScale = new Vector3(_radius, _radius) * 2f;
        }
        
        private void OnValidate()
        {
            UpdateProperties();
        }
        
#if UNITY_EDITOR
        
        private void OnDrawGizmosSelected()
        {
            Handles.color = Color.red;
            Handles.DrawWireDisc(transform.position, Vector3.forward, _radius, .1f);
        }
        
#endif // UNITY_EDITOR
    }
}