using UnityEngine;

namespace ImportantPrototype.Gameplay
{
    [RequireComponent(typeof(IDamageable))]
    public class SpawnOnDeathEffect : DeathEffect
    {
        [SerializeField]
        private GameObject _drop;
        
        protected override void Trigger()
        {
            DropItem();
        }
        
        private void DropItem()
        {
            Instantiate(_drop, transform.position, Quaternion.identity);
        }
    }
}