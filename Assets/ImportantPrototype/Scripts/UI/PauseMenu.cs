using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityTools.Runtime.Time;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI
{
    public class PauseMenu : Element
    {
        [SerializeField]
        private TimeManagerVariable _timeManager;

        [SerializeField]
        private Button _resumeButton;
        
        public override void Initialize()
        {
            _resumeButton
                .OnClickAsObservable()
                .Subscribe(_ => Resume())
                .AddTo(gameObject);
        }

        private void Resume()
        {
            Hide();
            _timeManager.Value.Resume();
        }
    }
}