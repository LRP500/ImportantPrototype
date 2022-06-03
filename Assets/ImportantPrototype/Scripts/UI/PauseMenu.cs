using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityTools.Runtime.Extensions;
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
        
        private readonly SerialDisposable _disposable = new ();
        
        public override void Initialize()
        {
            _disposable.AddTo(gameObject);

            _timeManager.Value.GamePaused
                .SkipFirst()
                .SubscribeTwoStates(Show, Hide)
                .AddTo(gameObject);
        }

        protected override void OnShow()
        {
            _disposable.Disposable = _resumeButton
                .OnClickAsObservable()
                .Subscribe(_ => _timeManager.Value.Resume());
        }
    }
}