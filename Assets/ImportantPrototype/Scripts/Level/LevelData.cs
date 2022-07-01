using System.Collections.Generic;
using ImportantPrototype.Characters.Enemies;
using ImportantPrototype.System;
using UnityEngine;

namespace ImportantPrototype.Level
{
    [CreateAssetMenu(menuName = ContextMenuPath.Root + "Level Data")]
    public class LevelData : ScriptableObject
    {
        [SerializeField]
        private string _name;

        [Multiline]
        [SerializeField]
        private string _description;

        [SerializeField]
        private List<EnemyWaveData> _waves;

        public IReadOnlyList<EnemyWaveData> Waves => _waves;
    }
}