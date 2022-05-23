using UnityEngine;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.Characters
{
    public class PlayerRenderer : CharacterRenderer
    {
        private PlayerAiming _aiming;

        protected override void OnInitialize()
        {
            _aiming = Character.GetComponent<PlayerAiming>();
        }
        
        protected override void UpdateFacingDirection()
        {
            var direction = _aiming.AimAngle.InRange(-90, 90) ? 1 : -1;
            var targetTransform = transform;
            var scale = targetTransform.localScale;
            scale.x = Mathf.Abs(scale.x) * direction;
            targetTransform.localScale = scale;
        }
    }
}