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

        public void Refresh()
        {
            var target = _player.Property.Value;
            if (target == null) return;
            // _self.Motor.Move(GetDirection(target.Position));
        }

        private Vector2 GetDirection(Vector2 destination)
        {
            return (destination - _self.Position).normalized;
        }
    }
}