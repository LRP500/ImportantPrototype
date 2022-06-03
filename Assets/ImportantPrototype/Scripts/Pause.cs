using ImportantPrototype.Input;
using UnityEngine;
using UnityTools.Runtime.Time;

namespace ImportantPrototype
{
    [RequireComponent(typeof(TimeManager))]
    public class Pause : MonoBehaviour
    {
        private TimeManager _timeManager;
        
        private void Awake()
        {
            _timeManager = GetComponent<TimeManager>();
        }

        private void Update()
        {
            if (PlayerInput.Pause)
            {
                _timeManager.TogglePause();
            }
        }
    }
}