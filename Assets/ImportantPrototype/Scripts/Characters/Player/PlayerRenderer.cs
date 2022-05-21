using UnityEngine;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.Characters
{
    public class PlayerRenderer : CharacterRenderer
    {
        private PlayerAim _aim;

        protected override void OnInitialize()
        {
            _aim = Character.GetComponent<PlayerAim>();
        }
        
        protected override void UpdateFacingDirection()
        {
            var direction = _aim.AimAngle.InRange(-90, 90) ? 1 : -1;
            var targetTransform = transform;
            var scale = targetTransform.localScale;
            scale.x = Mathf.Abs(scale.x) * direction;
            targetTransform.localScale = scale;
        }
    }
}