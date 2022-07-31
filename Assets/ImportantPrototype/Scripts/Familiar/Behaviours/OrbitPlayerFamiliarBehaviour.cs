using ImportantPrototype.System;
using UnityEngine;

namespace ImportantPrototype.Gameplay.Familiars
{
    [CreateAssetMenu(menuName = ContextMenuPath.FamiliarBehaviours + "Orbit Player")]
    public class OrbitPlayerFamiliarBehaviour : FamiliarBehaviour
    {
        public override void Initialize(Familiar familiar) { }

        public override void Refresh(Familiar familiar)
        {
            var speed = 20 * Time.deltaTime;
            var target = familiar.Owner.transform;
            familiar.transform.RotateAround(target.position, Vector3.up, speed);
        }
    }
}