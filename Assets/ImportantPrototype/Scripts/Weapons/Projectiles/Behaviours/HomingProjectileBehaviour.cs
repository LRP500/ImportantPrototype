using System;
using ImportantPrototype.Characters.Enemies;
using ImportantPrototype.System;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace ImportantPrototype.Weapons
{
    [CreateAssetMenu(menuName = ContextMenuPath.ProjectileBehaviours + "Homing")]
    public class HomingProjectileBehaviour : ProjectileBehaviour
    {
        private struct ResultInfo
        {
            public float distance;
            public float normalizeDot;
        }
        
        [SerializeField]
        private EnemyReactiveListVariable _enemies;

        [SerializeField]
        private float _minTargetDistance = 10;
        
        [Range(-1, 1)]
        [SerializeField]
        private float _maxTargetAlignment = 0;

        [Range(0, 1)]
        [SerializeField]
        private float _strength = 0.05f;
        
        [MinValue(0)]
        [SerializeField]
        private float _delay = 0.2f;

        [SerializeField]
        [MinValue(0.001)]
        private float _precision = 0.01f;
        
        private Transform _target;
        
        public override void Initialize(Projectile projectile)
        {
            projectile.Rigidbody.velocity = projectile.Direction * projectile.Speed;

            Observable
                .Interval(TimeSpan.FromSeconds(_precision))
                .DelaySubscription(TimeSpan.FromSeconds(_delay))
                .Subscribe(_ =>
                {
                    if (IsValidTarget(projectile, _target)) return;
                    _target = FindTarget(projectile);
                })
                .AddTo(projectile.gameObject);
        }

        private bool IsValidTarget(Projectile projectile, Transform target, out ResultInfo result)
        {
            result = new ResultInfo();
            if (target == null) return false;
            var originPos = projectile.Position;
            Vector2 targetPos = target.position;
            result.distance = Vector2.Distance(originPos, targetPos);
            result.normalizeDot = GetAlignment(originPos, projectile.Direction, targetPos);
            return result.distance < _minTargetDistance && result.normalizeDot >= _maxTargetAlignment;
        }

        private static float GetAlignment(Vector2 origin, Vector3 direction, Vector2 target)
        {
            var targetDir = (target - origin).normalized;
            return Vector2.Dot(targetDir, direction);
        }
        
        private bool IsValidTarget(Projectile projectile, Transform target)
        {
            return IsValidTarget(projectile, target, out _);
        }
        
        public override void Refresh(Projectile projectile)
        {
            Seek(projectile, _target);
        }

        private void Seek(Projectile projectile, Transform target)
        {
            if (target == null) return;
            var targetDir = (target.position - projectile.transform.position).normalized;
            var direction = Vector2.Lerp(projectile.Direction, targetDir, _strength * 10 * Time.deltaTime);
            projectile.Rigidbody.velocity = direction * projectile.Speed;
            projectile.Direction = direction;
        }
        
        private Transform FindTarget(Projectile projectile)
        {
            Enemy closest = null;
            float bestAlignment = 0;
            foreach (var enemy in _enemies.Values)
            {
                if (!IsValidTarget(projectile, enemy.transform, out var result)) continue;
                if (result.normalizeDot < bestAlignment) continue;
                bestAlignment = result.normalizeDot;
                closest = enemy;
            }

            return closest != null ? closest.transform : null;
        }
    }
}