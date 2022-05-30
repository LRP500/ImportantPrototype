using UnityEngine;

namespace ImportantPrototype.Weapons
{
    public abstract class ProjectileBehaviour : ScriptableObject
    {
        public virtual void Initialize(Projectile projectile) { }
        public virtual void Refresh(Projectile projectile) { }
    }
}