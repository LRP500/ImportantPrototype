using ImportantPrototype.System;
using UnityEngine;

namespace ImportantPrototype.Characters.Enemies
{
    [CreateAssetMenu(menuName = ContextMenuPath.Characters + "Enemy Data")]
    public class EnemyData : CharacterData
    {
        [SerializeField]
        private Enemy _prefab;

        public Enemy Prefab => _prefab;
    }
}