using Cinemachine;
using Extensions;
using ImportantPrototype.Input;
using ImportantPrototype.Weapons;
using UniRx;
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

        private readonly SerialDisposable _firingDisposable = new ();
        
        private void Awake()
        {
            _self = GetComponent<Player>();
        }

        private void OnEnable()
        {
            var weapon = _self.WeaponHolder.EquippedWeapon;

            _firingDisposable.Disposable = weapon.Data.FiringMode
                .FilterInput(weapon.Data, PlayerInput.ObserveFiring())
                .Subscribe(_ => OnFireInput(weapon));
        }

        private void OnDisable()
        {
            _firingDisposable?.Clear();
        }

        private void OnFireInput(Weapon weapon)
        {
            weapon.Fire(_self.Aiming.AimDirection, _projectileTag);
        }
    }
}
