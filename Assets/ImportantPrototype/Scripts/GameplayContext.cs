using ImportantPrototype.Characters.Enemies;
using ImportantPrototype.Leveling;
using ImportantPrototype.System;
using UnityEngine;
using UnityTools.Runtime.Variables;

namespace ImportantPrototype.Scripts
{
    [CreateAssetMenu(menuName = ContextMenuPath.Root + "Gameplay Context")]
    public class GameplayContext : ScriptableObject
    {
        [SerializeField]
        private EnemyManager _enemyManager;

        [SerializeField]
        private LevelManager _levelManager;
        
        [SerializeField]
        private GameObjectVariable _disposableTarget;

        private EnemyManager EnemyManager => _enemyManager;
        private LevelManager LevelManager => _levelManager;
        public GameObject DisposableTarget => _disposableTarget.Value;

        public void Initialize()
        {
            _enemyManager.Initialize(this);
            _levelManager.Initialize(this);
        }

        public void FixedUpdate()
        {
            _enemyManager.FixedUpdate();
        }
    }
}