using UnityEngine;

namespace ImportantPrototype.Characters.Enemies
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField]
        private PlayerReactiveVariable _player;

        private Enemy _self;

        private void Awake()
        {
            _self = GetComponent<Enemy>();
        }

        /// Empty OnEnable method to force checkbox visibility in editor 
        private void OnEnable() { }

        public void Refresh()
        {
            if (!enabled) return;
            var target = _player.Property.Value;
            if (target == null || !target.isActiveAndEnabled) return;
            _self.Motor.Move(GetDirection(target.Position));
        }

        private Vector2 GetDirection(Vector2 destination)
        {
            return (destination - _self.Position).normalized;
        }
    }
}