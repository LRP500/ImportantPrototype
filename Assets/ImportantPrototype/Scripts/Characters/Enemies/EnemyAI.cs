using UnityEngine;

namespace ImportantPrototype.Characters.Enemies
{
    [RequireComponent(typeof(Enemy))]
    [RequireComponent(typeof(EnemyMovement))]
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField]
        private PlayerReactiveVariable _player;

        private Enemy _self;
        private EnemyMovement _mover;

        private void Awake()
        {
            _self = GetComponent<Enemy>();
            _mover = GetComponent<EnemyMovement>();
        }

        public void Refresh()
        {
            var target = _player.Property.Value;
            if (target == null) return;
            _mover.Move(GetDirection(target.Position));
        }

        private Vector2 GetDirection(Vector2 destination)
        {
            return (destination - _self.Position).normalized;
        }
    }
}