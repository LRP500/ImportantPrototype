using UnityEngine;

namespace ImportantPrototype.Audio
{
    public class GameObjectAudio : MonoBehaviour
    {
        [SerializeField]
        private AK.Wwise.Event _event;

        private void Start()
        {
            _event.Post(gameObject);
        }

        private void OnDestroy()
        {
            _event.Stop(gameObject);
        }
    }
}