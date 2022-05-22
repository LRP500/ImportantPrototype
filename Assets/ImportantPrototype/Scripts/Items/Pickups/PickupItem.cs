using UnityEngine;

namespace ImportantPrototype.Items.Pickups
{
    public class PickupItem : MonoBehaviour
    {
        [SerializeField]
        private PickupItemData _item;
        
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (_item && _item.OnPick)
            {
                _item.OnPick.Execute();
            }
            
            Destroy(gameObject);
        }
    }
}