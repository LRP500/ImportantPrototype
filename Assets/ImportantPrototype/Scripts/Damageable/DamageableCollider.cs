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
            Damageable.CanDamage
                .StartWith(true)
                .Subscribe(gameObject.SetActive)
                .AddTo(gameObject);
        }
    }
}