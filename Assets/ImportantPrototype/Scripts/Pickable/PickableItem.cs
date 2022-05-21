using UnityEngine;

namespace ImportantPrototype.Pickable
{
    public class PickableItem : MonoBehaviour
    {
        [SerializeField]
        private string _name;
        
        public void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(gameObject);
        }
    }
}
