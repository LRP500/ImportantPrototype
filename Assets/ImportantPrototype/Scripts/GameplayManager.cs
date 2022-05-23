﻿using ImportantPrototype.Characters;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.ECA.Events;

namespace ImportantPrototype
{
    public class GameplayManager : MonoBehaviour
    {
        [SerializeField]
        private GameplayContext _context;

        [SerializeField]
        private PlayerReactiveVariable _player;

        [SerializeField]
        private ScriptableEvent _gameOverEvent;

        public void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _context.Initialize();
            _player.Value.Stats
                .ObserveValueChanged("health")
                .Where(value => value <= 0)
                .Subscribe(_ => GameOver());
        }

        private void FixedUpdate()
        {
            _context.FixedUpdate();
        }

        private void GameOver()
        {
            _player.Value.Freeze();
            _gameOverEvent.Raise();
        }
    }
}