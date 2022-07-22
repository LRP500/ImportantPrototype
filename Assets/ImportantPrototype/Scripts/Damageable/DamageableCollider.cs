using UniRx;
using UnityEngine;

namespace ImportantPrototype.Gameplay
{
    public class DamageableCollider : MonoBehaviour
    {
        [SerializeField]
        private Damageable _damageable;

        public Damageable Damageable => _damageable;

        private void Start()
        {
            Damageable.IsDamageable
                .StartWith(true)
                .Subscribe(gameObject.SetActive)
                .AddTo(gameObject);
        }
    }
}