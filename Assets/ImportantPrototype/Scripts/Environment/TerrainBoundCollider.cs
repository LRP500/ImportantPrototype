using ImportantPrototype.Characters;
using UnityEngine;

namespace ImportantPrototype.Environment
{
    public class TerrainBoundCollider : MonoBehaviour
    {
        [SerializeField]
        private PlayerReactiveVariable _player;

        private void LateUpdate()
        {
            transform.position = _player.Property.Value.Position;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Character"))
            {
                var character = other.GetComponentInParent<Character>();
                Destroy(character.gameObject);
            }
            else if (other.CompareTag("Projectile"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
