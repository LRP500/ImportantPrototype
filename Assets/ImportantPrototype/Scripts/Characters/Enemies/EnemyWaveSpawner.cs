using System;
using ImportantPrototype.Spawners;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ImportantPrototype.Characters.Enemies
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class EnemyWaveSpawner : Spawner2D<Enemy>, IDisposable
    {
        [SerializeField]
        private float _spawnInterval;
        
        [SerializeField]
        private int _maxSimultaneous;

        [SerializeField]
        private PlayerReactiveVariable _player;

        [SerializeField]
        private EnemyReactiveListVariable _enemies;
        
        private BoxCollider2D _area;
        private EnemyWaveData _currentWave;
        private readonly BoolReactiveProperty IsRunning = new ();
        private readonly SerialDisposable _runDisposable = new ();
        
        private void Awake()
        {
            _area = GetComponent<BoxCollider2D>();
            _runDisposable.AddTo(gameObject);
        }
        
        public void SetWave(EnemyWaveData wave)
        {
            _currentWave = wave;
            _spawnInterval = wave.SpawnInterval;
        }

        public void Run()
        {
            _runDisposable.Disposable = Observable
                .Interval(TimeSpan.FromSeconds(_spawnInterval))
                .Where(_ => _enemies.Values.Count < _maxSimultaneous)
                .DoOnSubscribe(() => IsRunning.Value = true)
                .TakeWhile(_ => IsRunning.Value)
                .Subscribe(_ => Spawn());
        }

        public void Stop()
        {
            IsRunning.Value = false;
        }
        
        protected override void Spawn()
        {
            var enemy = _currentWave.GetRandomItem();
            SetPrefab(enemy.Prefab);
            SpawnSingle();
        }
        
        private void LateUpdate()
        {
            // Update the spawner rect position based on player position.
            _area.offset = _player.Property.Value.Position;
        }

        protected override Vector2 GetPosition()
        {
            return GetRandomPointOnRect(_area.offset, _area.size);
        }
        
        /// https://stackoverflow.com/a/44418722/7511524
        private static Vector2 GetRandomPointOnRect(Vector2 origin, Vector2 size)
        {
            float rand = Random.value;
            var posX = Mathf.Min(1, Mathf.Max(0f, Mathf.Abs((rand * 4f - .5f) % 4 - 2) - .5f));
            var posY = Mathf.Min(1, Mathf.Max(0f, Mathf.Abs((rand * 4f + .5f) % 4 - 2) - .5f));
            return new Vector2(posX, posY) * size - size / 2 + origin;
        }

        public void Dispose()
        {
            _runDisposable?.Dispose();
        }
    }
}