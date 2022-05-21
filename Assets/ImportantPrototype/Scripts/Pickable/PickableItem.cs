using UnityEngine;

namespace ImportantPrototype.Pickable
{
    public class PickableItem : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(gameObject);
        }
    }
}
