using ImportantPrototype.UI.Common.Style;
using ImportantPrototype.Weapons;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.UI.MainMenu.Style
{
    public class WeaponSelectableStyleSetter : SelectableStyleSetter
    {
        [SerializeField]
        private WeaponDataReactiveVariable _selectedWeapon;

        private WeaponSelectionItemView View { get; set; }

        protected override void Awake()
        {
            View = GetComponent<WeaponSelectionItemView>();
            base.Awake();
        }
        
        protected virtual void OnEnable()
        {
            _selectedWeapon.Property
                .Subscribe(_ => Refresh())
                .AddToDisable(this);
        }

        protected override void Refresh()
        {
            if (View.Weapon == null)
            {
                SetNormal();
            }
            else if (_selectedWeapon.Value == View.Weapon)
            {
                SetSelected();
            }
            else
            {
                SetNormal();
            }
        }
    }
}