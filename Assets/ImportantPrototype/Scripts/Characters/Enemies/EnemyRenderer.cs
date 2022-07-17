using UnityEngine;

namespace ImportantPrototype.Characters.Enemies
{
    public class EnemyRenderer : CharacterRenderer
    {
        private CharacterMovement _movement;

        protected override void Initialize()
        {
            _movement = Character.GetComponent<CharacterMovement>();
            SetAnimation();
        }

        private void SetAnimation()
        {
            var enemyData = (EnemyData) Character.Data;
            Animator.runtimeAnimatorController = enemyData.Animation;
        }
        
        protected override void UpdateFacingDirection()
        {
            if (_movement.Velocity.x == 0) return;
            var direction = _movement.Velocity.x > 0 ? 1 : -1;
            var characterTransform = Character.transform;
            var scale = characterTransform.localScale;
            scale.x = Mathf.Abs(scale.x) * direction;
            Character.transform.localScale = scale;
        }
    }
}