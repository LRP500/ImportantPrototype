using DG.Tweening;
using UnityEngine;

namespace UnityTools.Runtime.Navigation
{
    public class SceneFader : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _canvasGroup;

        [Min(0)]
        [SerializeField]
        private float _duration = 1;
        
        private Tween _fadeTween;
        
        public void FadeIn(TweenCallback onComplete = null)
        {
            Fade(0, onComplete);
        }
        
        public void FadeOut(TweenCallback onComplete = null)
        {
            Fade(1, onComplete);
        }

        private void Fade(float target, TweenCallback onComplete)
        {
            _fadeTween?.Kill();
            _canvasGroup.blocksRaycasts = true;
            _fadeTween = _canvasGroup
                .DOFade(target, _duration)
                .SetUpdate(true);
            _fadeTween.timeScale = 1;

            _fadeTween.onComplete += () =>
            {
                onComplete?.Invoke();
                _canvasGroup.blocksRaycasts = false;
            };
        }
    }
}