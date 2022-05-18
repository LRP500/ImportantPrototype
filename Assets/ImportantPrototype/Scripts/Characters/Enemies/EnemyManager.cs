using ImportantPrototype.Scripts.Managers;
using ImportantPrototype.System;
using UnityEngine;

namespace ImportantPrototype.Characters.Enemies
{
    [CreateAssetMenu(menuName = ContextMenuPath.Managers + "Enemy Manager")]
    public class EnemyManager : ScriptableManager
    {
        [SerializeField]
        private EnemyReactiveList _enemies;

        protected override void OnFixedUpdate()
        {
            for (int i = 0, len = _enemies.Values.Count; i < len; ++i)
            {
                _enemies.Values[i].AI.Refresh();
            }
        }
    }
}