using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ImportantPrototype.Characters.Enemies
{
    [Serializable]
    public class EnemyWaveData
    {
        [Serializable]
        public class EnemySpawnInfo
        {
            [LabelWidth(50)]
            [HorizontalGroup(MarginRight = 8)]
            public EnemyData enemy;

            [LabelWidth(50)]
            [HorizontalGroup(MaxWidth = 150)]
            public int weight = 1;
        }

#if UNITY_EDITOR

        [Multiline(2)]
        [SerializeField]
        private string _description;

#endif // UNITY_EDITOR
        
        [SerializeField]
        private List<EnemySpawnInfo> _items;
        
        [SerializeField]
        [SuffixLabel("seconds", true)]
        private float _spawnInterval;

        [SerializeField]
        [SuffixLabel("seconds", true)]
        private float _duration;
        
        public IReadOnlyList<EnemySpawnInfo> Items => _items;
        public float SpawnInterval => _spawnInterval;
        public float Duration => _duration;
    }
}