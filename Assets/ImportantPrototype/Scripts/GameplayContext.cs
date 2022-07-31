using ImportantPrototype.Characters;
using ImportantPrototype.Characters.Enemies;
using ImportantPrototype.Gameplay.Familiars;
using ImportantPrototype.Gameplay.Mutations;
using ImportantPrototype.Leveling;
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
        private FamiliarManager _familiarManager;

        [SerializeField]
        private MutationManager _mutationManager;

        [SerializeField]
        private PlayerLevelManager _playerLevelManager;

        [SerializeField]
        private PlayerReactiveVariable _player;
        
        [SerializeField]
        private TransformVariable _disposableTarget;

        public FamiliarManager FamiliarManager => _familiarManager;
        public IReadOnlyReactiveProperty<Player> Player => _player.Property;
        public GameObject DisposableTarget => _disposableTarget.Value.gameObject;

        public void Initialize()
        {
            _enemyManager.Initialize(this);
            _familiarManager.Initialize(this);
            _mutationManager.Initialize(this);
            _playerLevelManager.Initialize(this);
        }

        public void FixedUpdate()
        {
            _enemyManager.FixedUpdate();
            _familiarManager.FixedUpdate();
        }

        public void Update()
        {
            _enemyManager.Update();
            _familiarManager.Update();
        }
    }
}