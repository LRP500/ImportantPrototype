using System.Collections.Generic;
using System.Linq;
using ImportantPrototype.Gameplay;
using ImportantPrototype.Input;
using ImportantPrototype.Weapons;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.UI;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI.MainMenu
{
    public class WeaponSelectionMenu : Element
    {
        [SerializeField]
        private WeaponSelectionItemView _itemView;

        [SerializeField]
        private GridLayoutGroup _gridLayout;

        [SerializeField]
        private WeaponDataReactiveVariable _selectedWeapon;
        
        private MainMenu _mainMenu;
        private IEnumerable<WeaponData> _weapons;
        private readonly List<WeaponSelectionItemView> _gridItems = new ();
        
        public override void Initialize()
        {
            _mainMenu = GetComponentInParent<MainMenu>();
            _weapons = GameContent.Instance.Weapons;
            _selectedWeapon.Clear();
            PopulateGrid();
            SelectFirst();
        }

        private void SelectFirst()
        {
            var firstWeapon = _weapons.ElementAt(0);
            _selectedWeapon.SetValue(firstWeapon);
        }

        private void PopulateGrid()
        {
            foreach (var weapon in _weapons)
            {
                var item = CreateItem(weapon);
                _gridItems.Add(item);
            }
        }

        private WeaponSelectionItemView CreateItem(WeaponData weapon)
        {
            var item = Instantiate(_itemView, _gridLayout.transform);
            item.Bind(weapon);
            return item;
        }

        protected override void OnShow()
        {
            if (_gridItems.IsNullOrEmpty()) return;
            _gridItems[0].Select();
        }

        private void Update()
        {
            if (PlayerInput.Back)
            {
                _mainMenu.NavigateToTitleMenu();
            }
        }
    }
}