using ImportantPrototype.Characters.Enemies;
using UnityEngine;

namespace ImportantPrototype.Scripts
{
    public class GameplayManager : MonoBehaviour
    {
        [SerializeField]
        private GameplayContext _context;

        [SerializeField]
        private EnemyManager _enemyManager;
        
        public void Start()
        {
            _enemyManager.Initialize(_context);
        }
        
        private void FixedUpdate()
        {
            _enemyManager.FixedUpdate();
        }
    }
}