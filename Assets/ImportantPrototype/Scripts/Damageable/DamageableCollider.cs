using UniRx;
using UnityEngine;

namespace ImportantPrototype.Gameplay
{
    public class DamageableCollider : MonoBehaviour
    {
        [SerializeField]
        private string _collisionLayer;
        
        [SerializeField]
        private Damageable _damageable;

        public Damageable Damageable => _damageable;

        private void Awake()
        {
            SetLayer();
        }

        private void Start()
        {
            Damageable.CanDamage
                .StartWith(true)
                .Subscribe(gameObject.SetActive)
                .AddTo(gameObject);
        }

        private void SetLayer()
        {
            var layer = LayerMask.NameToLayer(_collisionLayer);
            if (layer == -1) return;
            gameObject.layer = layer;
        }
    }
}