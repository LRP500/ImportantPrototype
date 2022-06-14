using ImportantPrototype.Weapons;
using UnityEngine;
using UnityEngine.Serialization;

namespace ImportantPrototype.Characters
{
    [RequireComponent(typeof(PlayerAiming))]
    [RequireComponent(typeof(PlayerShooting))]
    public class Player : Character
    {
        [SerializeField]
        private PlayerData _data;

        [FormerlySerializedAs("_weaponHolder")]
        [SerializeField]
        private WeaponController _weaponController;

        public WeaponController WeaponController => _weaponController;
        
        public PlayerAiming Aiming { get; private set; }
        public PlayerShooting Shooting { get; private set; }
        
        protected override void OnInitialize()
        {
            Aiming = GetComponent<PlayerAiming>();
            Shooting = GetComponent<PlayerShooting>();
            
            WeaponController.EquipWeapon(_data.Weapon);
        }

        public void Freeze()
        {
            Motor.enabled = false;
            Aiming.enabled = false;
            Shooting.enabled = false;
        }
    }
}