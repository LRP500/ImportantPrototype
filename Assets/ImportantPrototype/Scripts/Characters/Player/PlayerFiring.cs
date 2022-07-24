using Cinemachine;
using ImportantPrototype.Input;
using ImportantPrototype.Weapons;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.Extensions;
using UnityTools.Runtime.Time;

namespace ImportantPrototype.Characters
{
    [RequireComponent(typeof(Player))]
    public class PlayerFiring : MonoBehaviour
    {
        public readonly ISubject<Unit> OnFire = new Subject<Unit>();

        [TagField]
        [SerializeField]
        private string _projectileTag;

        private Player _self;

        private readonly SerialDisposable _firingDisposable = new ();

        private void Awake()
        {
            _self = GetComponent<Player>();
            _firingDisposable.AddTo(gameObject);
        }

        private void Start()
        {
            _self.Weapon
                .Subscribe(OnEquippedWeaponChanged)
                .AddTo(gameObject);
        }

        private void OnEquippedWeaponChanged(Weapon weapon)
        {
            if (weapon == null)
            {
                _firingDisposable.Clear();
                return;
            }

            RegisterWeapon(weapon);
        }
        
        private void RegisterWeapon(Weapon weapon)
        {
            _firingDisposable.Disposable = weapon.Data.FiringMode
                .FilterInput(weapon, PlayerInput.ObserveFiring())
                .Subscribe(_ => OnFireInput(weapon));
        }
        
        private void OnFireInput(Weapon weapon)
        {
            if (TimeManager.Current.GamePaused.Value) return;
            weapon.Fire(_self.Aiming.AimDirection, _projectileTag);
            OnFire.OnNext(Unit.Default);
        }
    }
}
