using ImportantPrototype.System;
using UnityEngine;

namespace ImportantPrototype.Weapons
{
    [CreateAssetMenu(menuName = ContextMenuPath.ProjectileBehaviours + "Simple")]
    public class SimpleProjectileBehaviour : ProjectileBehaviour
    {
        public override void Initialize(Projectile projectile)
        {
            projectile.Rigidbody.velocity = projectile.Direction * projectile.Speed;
        }
    }
}