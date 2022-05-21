using ImportantPrototype.Pickable;
using UnityEngine;

namespace ImportantPrototype.Characters.Enemies
{
    [RequireComponent(typeof(EnemyAI))]
    public class Enemy : Character
    {
        [SerializeField]
        private PickableItem _drop;
        
        public EnemyAI AI { get; private set; }

        protected override void OnInitialize()
        {
            AI = GetComponent<EnemyAI>();
        }

        public override void OnDeath()
        {
            DropItem();
            Destroy(gameObject);
        }

        private void DropItem()
        {
            Instantiate(_drop, transform.position, Quaternion.identity);
        }
    }
}
