using ImportantPrototype.Weapons;
using UnityEngine;

namespace ImportantPrototype.Characters
{
    [RequireComponent(typeof(PlayerAiming))]
    [RequireComponent(typeof(PlayerShooting))]
    public class Player : Character
    {
        [SerializeField]
        private PlayerData _data;

        public PlayerAiming Aiming { get; private set; }
        public PlayerShooting Shooting { get; private set; }
        public WeaponHolder WeaponHolder { get; private set; }
        
        protected override void OnInitialize()
        {
            Aiming = GetComponent<PlayerAiming>();
            Shooting = GetComponent<PlayerShooting>();
            WeaponHolder = GetComponentInChildren<WeaponHolder>();
            WeaponHolder.EquipWeapon(_data.Weapon);
        }

        public void Freeze()
        {
            Motor.enabled = false;
            Aiming.enabled = false;
            Shooting.enabled = false;
        }
    }
}