using UnityEngine;

namespace ImportantPrototype.Scripts.Managers
{
    public abstract class ScriptableManager : ScriptableObject
    {
        public GameplayContext Context { get; private set; }

        public void Initialize(GameplayContext context)
        {
            Context = context;
            OnInitialize();
        }

        public void Update()
        {
            OnUpdate();
        }

        public void FixedUpdate()
        {
            OnFixedUpdate();
        }
        
        protected virtual void OnInitialize() { }
        protected virtual void OnUpdate() { }
        protected virtual void OnFixedUpdate() { }
    }
}