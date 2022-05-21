using Sirenix.OdinInspector;
using UnityEngine;

namespace ImportantPrototype.Spawners
{
    public abstract class Spawner2D<T> : MonoBehaviour where T : Component
    {
        [SerializeField]
        private T _prefab;

        [SerializeField]
        protected bool _spawnOnStart = true;
        
        [SerializeField]
        private bool _destroyAfterSpawn;
        
        protected virtual void Start()
        {
            OnStart();
            
            if (_spawnOnStart)
            {
                Spawn();
            }
            
            if (_destroyAfterSpawn)
            {
                Destroy(gameObject);
            }
        }

        protected virtual void OnStart() { }

        protected void SpawnSingle(Vector2 position)
        {
            var instance = Instantiate(_prefab, transform);
            instance.transform.position = position;
            OnSpawn(instance);
        }
        
        protected virtual void Spawn() { }
        protected virtual void OnSpawn(T entity) { }
    }
}
