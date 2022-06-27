using UnityEngine;
using UnityTools.Runtime.Variables;

namespace ImportantPrototype.Level
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField]
        private FloatVariable _gameStartTime;
        
        [SerializeField]
        private IntReactiveVariable _currentWave;
        
        public void StartLevel()
        {
            _currentWave.SetValue(1);
            _gameStartTime.SetValue(Time.time);
        }
    }
}