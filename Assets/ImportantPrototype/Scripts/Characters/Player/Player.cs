using ImportantPrototype.Weapons;
using UniRx;
using UnityEngine;

namespace ImportantPrototype.Characters
{
    [RequireComponent(typeof(PlayerAiming))]
    [RequireComponent(typeof(PlayerFiring))]
    public class Player : Character
    {
        [SerializeField]
        private WeaponHolder _weaponHolder;

        public WeaponHolder WeaponHolder => _weaponHolder;
        public IReadOnlyReactiveProperty<Weapon> Weapon => _weaponHolder.Weapon;
        
        public PlayerAiming Aiming { get; private set; }
        public PlayerFiring Firing { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            Aiming = GetComponent<PlayerAiming>();
            Firing = GetComponent<PlayerFiring>();
        }

        protected override void OnInitialize()
        {
            WeaponHolder.Initialize();
        }

        public void Freeze()
        {
            Motor.enabled = false;
            Aiming.enabled = false;
            Firing.enabled = false;
        }

        public override void OnDeath()
        {
            gameObject.SetActive(false);
        }
    }
}