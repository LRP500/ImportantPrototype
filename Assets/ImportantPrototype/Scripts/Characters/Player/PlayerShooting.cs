using Cinemachine;
using ImportantPrototype.Input;
using UnityEngine;

namespace ImportantPrototype.Characters
{
    [RequireComponent(typeof(Player))]
    public class PlayerShooting : MonoBehaviour
    {
        [TagField]
        [SerializeField]
        private string _projectileTag;
        
        private Player _self;

        private void Awake()
        {
            _self = GetComponent<Player>();
        }

        private void Update()
        {
            if (!PlayerInput.Fire) return;
            var weapon = _self.Aiming.WeaponHolder.Weapon; 
            weapon.Fire(_self.Aiming.AimDirection, _projectileTag);
        }
    }
}
