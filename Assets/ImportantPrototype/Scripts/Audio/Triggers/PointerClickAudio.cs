using UnityEngine;
using UnityEngine.EventSystems;

namespace ImportantPrototype.Audio.Triggers
{
    public class PointerClickAudio : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private AK.Wwise.Event _event;

        public void OnPointerClick(PointerEventData eventData)
        {
            _event.Post(gameObject);
        }
    }
}
