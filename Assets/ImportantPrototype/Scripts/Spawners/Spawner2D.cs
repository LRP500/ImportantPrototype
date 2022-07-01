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

        [SerializeField]
        private Transform _container;

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

        protected void SetPrefab(T prefab)
        {
            _prefab = prefab;
        }
        
        protected void SpawnSingle(Vector2 position)
        {
            var container = _container != null ? _container : transform;
            var instance = Instantiate(_prefab, container);
            instance.transform.position = position;
            OnSpawn(instance);
        }
        
        protected void SpawnSingle()
        {
            var position = GetPosition();
            SpawnSingle(position);
        }
        
        protected virtual void Spawn() { }
        protected virtual void OnSpawn(T entity) { }
        protected virtual Vector2 GetPosition() => transform.position;
    }
}
