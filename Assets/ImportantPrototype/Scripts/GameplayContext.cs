using ImportantPrototype.Characters;
using ImportantPrototype.Characters.Enemies;
using ImportantPrototype.Leveling;
using ImportantPrototype.Mutations;
using ImportantPrototype.System;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;
using UnityTools.Runtime.Variables;

namespace ImportantPrototype
{
    [CreateAssetMenu(menuName = ContextMenuPath.Root + "Gameplay Context")]
    public class GameplayContext : ScriptableObject
    {
        [SerializeField]
        private EnemyManager _enemyManager;

        [FormerlySerializedAs("_levelManager")]
        [SerializeField]
        private PlayerLevelManager _playerLevelManager;

        [SerializeField]
        private MutationManager _mutationManager;
        
        [SerializeField]
        private PlayerReactiveVariable _player;
        
        [SerializeField]
        private TransformVariable _disposableTarget;

        public EnemyManager EnemyManager => _enemyManager;
        public PlayerLevelManager PlayerLevelManager => _playerLevelManager;
        public IReadOnlyReactiveProperty<Player> Player => _player.Property;
        public GameObject DisposableTarget => _disposableTarget.Value.gameObject;

        public void Initialize()
        {
            _enemyManager.Initialize(this);
            _playerLevelManager.Initialize(this);
            _mutationManager.Initialize(this);
        }

        public void FixedUpdate()
        {
            _enemyManager.FixedUpdate();
        }
    }
}