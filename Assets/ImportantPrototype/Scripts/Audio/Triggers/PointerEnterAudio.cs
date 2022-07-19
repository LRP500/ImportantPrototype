using UnityEngine;
using UnityEngine.EventSystems;

namespace ImportantPrototype.Audio.Triggers
{
    public class PointerEnterAudio : MonoBehaviour, IPointerEnterHandler
    {
        [SerializeField]
        private AK.Wwise.Event _event;

        public void OnPointerEnter(PointerEventData eventData)
        {
            _event.Post(gameObject);
        }
    }
}