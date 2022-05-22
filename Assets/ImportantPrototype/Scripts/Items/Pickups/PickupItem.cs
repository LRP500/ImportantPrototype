using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ImportantPrototype.Items.Pickups
{
    public class PickupItem : MonoBehaviour
    {
        [SerializeField]
        private PickupItemData _item;

        [SerializeField]
        private float _moveSpeed = 5;

        private IDisposable _pickUpDisposable;
        
        public void OnTriggerEnter2D(Collider2D other)
        {
            // PickUp();
            OnPickupRadiusEnter(other.transform);
        }

        private void OnPickupRadiusEnter(Transform other)
        {
            this.UpdateAsObservable()
                .Select(_ => RemainingDistance(other.position))
                .TakeWhile(distance => distance > 1)
                .Subscribe(_ => MoveTowards(other.transform.position), PickUp)
                .AddTo(gameObject);
        }

        private float RemainingDistance(Vector2 other)
        {
            return Vector2.Distance(other, transform.position);
        }

        private void MoveTowards(Vector2 destination)
        {
            var self = transform;
            var position = self.position;
            var direction = (destination - (Vector2) position).normalized;
            position += (Vector3) direction * _moveSpeed * Time.deltaTime;
            self.position = position;
        }
        
        private void PickUp()
        {
            if (_item && _item.OnPick)
            {
                _item.OnPick.Execute();
            }
            
            Destroy(gameObject);
        }
    }
}