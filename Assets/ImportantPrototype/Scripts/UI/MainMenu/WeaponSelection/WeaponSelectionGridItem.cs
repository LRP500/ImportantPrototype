using System;
using ImportantPrototype.Weapons;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityTools.Runtime.Extensions;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI.MainMenu
{
    public class WeaponSelectionGridItem : Element
    {
        [SerializeField]
        private TextMeshProUGUI _weaponName;

        [SerializeField]
        private Toggle _toggle;
        
        private WeaponData _weapon;

        public override void Initialize()
        {
            _toggle.group = GetComponentInParent<ToggleGroup>();
        }

        public void Bind(WeaponData weapon)
        {
            _weapon = weapon;
            Refresh();
        }

        public IObservable<WeaponData> ObserveSelect()
        {
            return _toggle.OnToggleOn().Select(_ => _weapon);
        }

        public override void Refresh()
        {
            _weaponName.SetText(_weapon.Name);
        }

        public void Select()
        {
            _toggle.isOn = true;
        }
    }
}