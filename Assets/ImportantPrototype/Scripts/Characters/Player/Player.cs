using ImportantPrototype.Weapons;
using UniRx;
using UnityEngine;

namespace ImportantPrototype.Characters
{
    [RequireComponent(typeof(PlayerAiming))]
    [RequireComponent(typeof(PlayerShooting))]
    public class Player : Character
    {
        [SerializeField]
        private WeaponHolder _weaponHolder;

        public WeaponHolder WeaponHolder => _weaponHolder;
        public IReadOnlyReactiveProperty<Weapon> Weapon => _weaponHolder.Weapon;
        
        public PlayerAiming Aiming { get; private set; }
        public PlayerShooting Shooting { get; private set; }
        
        protected override void OnInitialize()
        {
            Aiming = GetComponent<PlayerAiming>();
            Shooting = GetComponent<PlayerShooting>();
            WeaponHolder.EquipWeapon(Data.Weapon);
        }

        public void Freeze()
        {
            Motor.enabled = false;
            Aiming.enabled = false;
            Shooting.enabled = false;
        }
    }
}