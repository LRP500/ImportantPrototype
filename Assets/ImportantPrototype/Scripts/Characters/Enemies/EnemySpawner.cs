using System;
using ImportantPrototype.Spawners;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ImportantPrototype.Characters.Enemies
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class EnemySpawner : Spawner2D<Enemy>
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

        private void Awake()
        {
            _area = GetComponent<BoxCollider2D>();
        }

        protected override void OnStart()
        {
            Observable.Interval(TimeSpan.FromSeconds(_spawnInterval))
                .Where(_ => _enemies.Count < _maxSimultaneous)
                .Subscribe(_ => Spawn())
                .AddTo(this);
        }
        
        private void LateUpdate()
        {
            // Update the spawner rect position based on player position.
            _area.offset = _player.Property.Value.Position;
        }

        protected override void Spawn()
        {
            var position = GetRandomPointOnRect(_area.offset, _area.size);
            SpawnSingle(position);
        }

        /// https://stackoverflow.com/a/44418722/7511524
        private static Vector2 GetRandomPointOnRect(Vector2 origin, Vector2 size)
        {
            float rand = Random.value;
            var posX = Mathf.Min(1, Mathf.Max(0f, Mathf.Abs((rand * 4f - .5f) % 4 - 2) - .5f));
            var posY = Mathf.Min(1, Mathf.Max(0f, Mathf.Abs((rand * 4f + .5f) % 4 - 2) - .5f));
            return new Vector2(posX, posY) * size - size / 2 + origin;
        }
    }
}