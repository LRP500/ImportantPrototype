using UnityEngine;

namespace ImportantPrototype.Spawners
{
    public abstract class Spawner2D<T> : MonoBehaviour where T : Transform
    {
        [SerializeField]
        private T _prefab;

        [SerializeField]
        protected bool _spawnOnStart = true;
        
        private void Start()
        {
            if (_spawnOnStart)
            {
                Spawn();
            }
        }
        
        protected void SpawnSingle(Vector2 position)
        {
            var instance = Instantiate(_prefab, transform);
            instance.transform.position = position;
        }
        
        protected virtual void Spawn() { }
    }
}
