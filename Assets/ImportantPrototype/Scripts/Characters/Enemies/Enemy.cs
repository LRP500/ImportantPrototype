using UnityEngine;

namespace ImportantPrototype.Characters.Enemies
{
    [RequireComponent(typeof(EnemyAI))]
    public class Enemy : Character
    {
        public EnemyAI AI { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            AI = GetComponent<EnemyAI>();
        }
    }
}