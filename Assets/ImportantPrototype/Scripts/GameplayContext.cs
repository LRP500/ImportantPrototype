using ImportantPrototype.Characters;
using ImportantPrototype.Characters.Enemies;
using ImportantPrototype.Leveling;
using ImportantPrototype.Mutations;
using ImportantPrototype.System;
using UniRx;
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
        private MutationManager _mutationManager;
        
        [SerializeField]
        private PlayerReactiveVariable _player;
        
        [SerializeField]
        private TransformVariable _disposableTarget;

        public EnemyManager EnemyManager => _enemyManager;
        public LevelManager LevelManager => _levelManager;
        public IReadOnlyReactiveProperty<Player> Player => _player.Property;
        public GameObject DisposableTarget => _disposableTarget.Value.gameObject;

        public void Initialize()
        {
            _enemyManager.Initialize(this);
            _levelManager.Initialize(this);
            _mutationManager.Initialize(this);
        }

        public void FixedUpdate()
        {
            _enemyManager.FixedUpdate();
        }
    }
}