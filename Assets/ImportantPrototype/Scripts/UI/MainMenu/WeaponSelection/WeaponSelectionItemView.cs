using ImportantPrototype.Weapons;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI.MainMenu
{
    public class WeaponSelectionItemView : Element, IPointerClickHandler
    {
        [SerializeField]
        private TextMeshProUGUI _weaponName;

        [SerializeField]
        private WeaponDataReactiveVariable _selectedWeapon;
        
        public WeaponData Weapon { get; private set; }

        public void Bind(WeaponData weapon)
        {
            Weapon = weapon;
            Refresh();
        }

        public override void Refresh()
        {
            _weaponName.SetText(Weapon.Name);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Select();
        }
        
        public void Select()
        {
            _selectedWeapon.SetValue(Weapon);
        }
    }
}