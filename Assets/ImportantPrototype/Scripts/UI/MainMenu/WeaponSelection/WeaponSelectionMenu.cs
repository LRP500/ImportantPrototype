using System.Collections.Generic;
using System.Linq;
using ImportantPrototype.Content;
using ImportantPrototype.Input;
using ImportantPrototype.Weapons;
using Sirenix.Utilities;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI.MainMenu
{
    public class WeaponSelectionMenu : Element
    {
        [SerializeField]
        private WeaponSelectionGridItem _gridItem;

        [SerializeField]
        private GridLayoutGroup _gridLayout;
        
        private MainMenu _mainMenu;
        private List<WeaponSelectionGridItem> _gridItems = new ();
        
        public override void Initialize()
        {
            _mainMenu = GetComponentInParent<MainMenu>();
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            foreach (var weapon in GameContent.Current.Weapons)
            {
                var item = CreateItem(weapon);
                _gridItems.Add(item);
            }
        }

        private void OnWeaponSelected(WeaponData weapon)
        {
            Debug.Log($"Weapon selected! ({weapon.Name})");
        }
        
        private WeaponSelectionGridItem CreateItem(WeaponData weapon)
        {
            var item = Instantiate(_gridItem, _gridLayout.transform);
            item.Bind(weapon);
            item.ObserveSelect()
                .Subscribe(OnWeaponSelected)
                .AddTo(gameObject);
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