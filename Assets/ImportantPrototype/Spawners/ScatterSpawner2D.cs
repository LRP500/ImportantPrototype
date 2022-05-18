using UnityEngine;
using Random = UnityEngine.Random;

namespace ImportantPrototype.Spawners
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class ScatterSpawner2D<T> : Spawner2D<T> where T : Transform
    {
        [Range(0, 1)]
        [SerializeField]
        private float _density = 1;
        
        private BoxCollider2D _area;

        private void Awake()
        {
            _area = GetComponent<BoxCollider2D>();
        }

        protected override void Spawn()
        {
            var areaSize = _area.size;
            var count = Mathf.RoundToInt(areaSize.x * areaSize.y * _density);

            for (int i = 0; i < count; ++i)
            {
                var position = GetRandomPositionInBounds(_area.bounds);
                SpawnSingle(position);
            }
        }

        private static Vector2 GetRandomPositionInBounds(Bounds areaBounds)
        {
            var posX = Random.Range(areaBounds.min.x, areaBounds.max.x);
            var posY = Random.Range(areaBounds.min.y, areaBounds.max.y);
            return new Vector2(posX, posY);
        }
    }
}
