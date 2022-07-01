using System;
using ImportantPrototype.Characters.Enemies;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.Variables;

namespace ImportantPrototype.Level
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField]
        private FloatVariable _gameStartTime;

        [SerializeField]
        private LevelData _level;
        
        [SerializeField]
        private IntReactiveVariable _currentWaveCount;

        [SerializeField]
        private EnemyWaveSpawner _spawner;

        private readonly SerialDisposable _waveDisposable = new ();
        
        public void StartLevel()
        {
            _gameStartTime.SetValue(Time.time);
            _currentWaveCount.SetValue(0);
            StartWave(GetWave(0));
        }

        private void OnLevelEnd() { }
        
        private void StartWave(EnemyWaveData wave)
        {
            _spawner.SetWave(wave);
            
            _waveDisposable.Disposable = Observable
                .Timer(TimeSpan.FromSeconds(wave.Duration))
                .DoOnSubscribe(_spawner.Run)
                .DoOnCompleted(OnWaveEnd)
                .Subscribe();
        }
        
        private void OnWaveEnd()
        {
            _spawner.Stop();
            
            if (_currentWaveCount.Value >= _level.Waves.Count - 1)
            {
                OnLevelEnd();
                return;
            }
            
            _currentWaveCount.Increment();
            var nextWave = GetWave(_currentWaveCount.Value);
            StartWave(nextWave);
        }
        
        private EnemyWaveData GetWave(int index)
        {
            return _level.Waves[index];
        }
    }
}