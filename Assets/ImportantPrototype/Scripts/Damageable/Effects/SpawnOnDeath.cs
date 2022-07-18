using UnityEngine;

namespace ImportantPrototype.Gameplay
{
    [RequireComponent(typeof(IDamageable))]
    public class SpawnOnDeath : DeathEffect
    {
        [SerializeField]
        private GameObject _toSpawn;
        
        protected override void Trigger()
        {
            DropItem();
        }
        
        private void DropItem()
        {
            Instantiate(_toSpawn, transform.position, Quaternion.identity);
        }
    }
}