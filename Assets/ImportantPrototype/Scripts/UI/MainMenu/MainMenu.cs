using UnityEngine;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private Element _title;

        [SerializeField]
        private Element _weaponSelection;

        private void Awake()
        {
            NavigateToTitleMenu();
        }

        public void NavigateToTitleMenu()
        {
            _weaponSelection.Hide();
            _title.Show();
        }
        
        public void NavigateToWeaponSelection()
        {
            _title.Hide();
            _weaponSelection.Show();
        }
    }
}
