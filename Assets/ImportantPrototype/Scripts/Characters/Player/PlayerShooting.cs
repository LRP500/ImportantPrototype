using ImportantPrototype.Input;
using ImportantPrototype.Weapons;
using UnityEngine;

namespace ImportantPrototype.Characters
{
    [RequireComponent(typeof(PlayerAim))]
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField]
        private Weapon _currentWeapon;

        private PlayerAim _aim;

        private void Awake()
        {
            _aim = GetComponent<PlayerAim>();
        }

        private void Update()
        {
            if (PlayerInput.Fire)
            {
                _currentWeapon.Fire(_aim.Direction);
            }
        }
    }
}
