using UniRx;
using UnityEngine;
using Attribute = ImportantPrototype.Stats.Attribute;

namespace ImportantPrototype.Characters
{
    public class PlayerPickupArea : MonoBehaviour
    {
        [SerializeField]
        private CircleCollider2D _collider;

        private Player _player;
        private Attribute _range;

        private void Awake()
        {
            _player = GetComponentInParent<Player>();
        }

        private void Start()
        {
            _range = _player.Stats.Get<Attribute>(CharacterStatType.PickupRange);
            _range.Property.Subscribe(SetRadius).AddTo(gameObject);
        }

        private void SetRadius(float range)
        {
            _collider.radius = range;
        }
    }
}
