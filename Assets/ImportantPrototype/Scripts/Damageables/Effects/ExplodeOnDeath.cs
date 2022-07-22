using UnityEngine;

namespace ImportantPrototype.Damageables.Effects
{
    public class ExplodeOnDeath : DeathEffect
    {
        [SerializeField]
        private Explosion _explosionPrefab;
        
        protected override void Trigger()
        {
            var instance = Instantiate(_explosionPrefab);
            instance.transform.position = transform.position;
            instance.Trigger();
        }
    }
}