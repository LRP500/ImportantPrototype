using ImportantPrototype.Input;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.ECA.Events;
using UnityTools.Runtime.Time;

namespace ImportantPrototype
{
    public class PauseManager : MonoBehaviour
    {
        [SerializeField]
        private ScriptableEvent _pauseToggledEvent;

        public static bool AllowPausing { get; set; } = true;
        
        private void Awake()
        {
            PlayerInput.ObservePause()
                .Where(_ => AllowPausing)
                .Subscribe(_ => TogglePause())
                .AddTo(gameObject);
        }
        
        private void TogglePause()
        {
            _pauseToggledEvent.Raise();
            TimeManager.Current.TogglePause();
        }

        public static void Pause()
        {
            TimeManager.Current.Pause();
        }
        
        public static void Resume()
        {
            TimeManager.Current.Resume();
            AllowPausing = true;
        }
    }
}