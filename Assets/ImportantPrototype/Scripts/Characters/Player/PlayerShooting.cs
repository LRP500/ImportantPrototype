using Cinemachine;
using ImportantPrototype.Input;
using UnityEngine;

namespace ImportantPrototype.Characters
{
    [RequireComponent(typeof(PlayerAim))]
    public class PlayerShooting : MonoBehaviour
    {
        [TagField]
        [SerializeField]
        private string _projectileTag;
        
        private PlayerAim _aim;

        private void Awake()
        {
            _aim = GetComponent<PlayerAim>();
        }

        private void Update()
        {
            if (!PlayerInput.Fire) return;
            var weapon = _aim.WeaponHolder.Weapon; 
            weapon.Fire(_aim.AimDirection, _projectileTag);
        }
    }
}
