using UnityEngine;

namespace ImportantPrototype.Spawners
{
    public abstract class Spawner2D<T> : MonoBehaviour where T : Transform
    {
        [SerializeField]
        private T _prefab;

        [SerializeField]
        protected bool _spawnOnStart = true;
        
        protected virtual void Start()
        {
            OnStart();
            
            if (_spawnOnStart)
            {
                Spawn();
            }
        }

        protected virtual void OnStart() { }

        protected void SpawnSingle(Vector2 position)
        {
            var instance = Instantiate(_prefab, transform);
            instance.transform.position = position;
        }
        
        protected virtual void Spawn() { }
    }
}
