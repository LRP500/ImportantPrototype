using UnityEngine;

namespace ImportantPrototype.Damageables.Effects
{
    public class DestroyOnDeath : DeathEffect
    {
        [SerializeField]
        private GameObject _root;
        
        protected override void Trigger()
        {
            Destroy(_root);
        }
    }
}