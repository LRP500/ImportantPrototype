using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace ImportantPrototype.Audio.Triggers
{
    [RequireComponent(typeof(Button))]
    public class ButtonAudio : MonoBehaviour
    {
        [SerializeField]
        private AK.Wwise.Event _highlightEvent;

        [SerializeField]
        private AK.Wwise.Event _selectEvent;

        private void Awake()
        {
            var button = GetComponent<Button>();
            
            button.OnPointerEnterAsObservable()
                .Where(_ => button.interactable)
                .Subscribe(_ => _highlightEvent.Post(gameObject))
                .AddTo(gameObject);
            
            button.OnClickAsObservable()
                .Subscribe(_ => _selectEvent.Post(gameObject))
                .AddTo(gameObject);
        }
    }
}