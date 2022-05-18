using ImportantPrototype.Spawners;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ImportantPrototype.Characters.Enemies
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class EnemySpawner : Spawner2D<Transform>
    {
        [SerializeField]
        private Player _player;
        
        private BoxCollider2D _area;

        private void Awake()
        {
            _area = GetComponent<BoxCollider2D>();
        }

        private void Update()
        {
            UpdatePosition();
        }

        /// <summary>
        /// Refresh the spawner position based on current player position.
        /// </summary>
        private void UpdatePosition()
        {
            _area.offset = _player.Position;
        }

        [Button]
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