using UnityEngine;

namespace ImportantPrototype.Characters.Enemies
{
    [RequireComponent(typeof(EnemyAI))]
    public class Enemy : Character
    {
        public EnemyAI AI { get; private set; }

        protected override void OnInitialize()
        {
            AI = GetComponent<EnemyAI>();
        }

        public override void OnDeath()
        {
            Destroy(gameObject);
        }
    }
}
