using ImportantPrototype.Characters.Enemies;
using ImportantPrototype.Leveling;
using ImportantPrototype.System;
using UnityEngine;
using UnityTools.Runtime.Variables;

namespace ImportantPrototype
{
    [CreateAssetMenu(menuName = ContextMenuPath.Root + "Gameplay Context")]
    public class GameplayContext : ScriptableObject
    {
        [SerializeField]
        private EnemyManager _enemyManager;

        [SerializeField]
        private LevelManager _levelManager;
        
        [SerializeField]
        private TransformVariable _disposableTarget;

        private EnemyManager EnemyManager => _enemyManager;
        private LevelManager LevelManager => _levelManager;
        public GameObject DisposableTarget => _disposableTarget.Value.gameObject;

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