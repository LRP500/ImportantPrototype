using System;
using System.Collections.Generic;
using UnityEngine;

namespace ImportantPrototype.Characters.Enemies
{
    [Serializable]
    public class EnemyWaveData
    {
        [SerializeField]
        private List<EnemyData> _enemies;
        
        [SerializeField]
        private float _spawnInterval;

        [SerializeField]
        private float _duration;
        
        public IReadOnlyList<EnemyData> Enemies => _enemies;
        public float SpawnInterval => _spawnInterval;
        public float Duration => _duration;
    }
}