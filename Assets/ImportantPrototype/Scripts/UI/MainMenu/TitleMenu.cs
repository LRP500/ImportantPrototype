using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI.MainMenu
{
    public class TitleMenu : Element
    {
        [SerializeField]
        private Button _playButton;

        private MainMenu _mainMenu;

        public override void Initialize()
        {
            _mainMenu = GetComponentInParent<MainMenu>();
            _playButton.OnClickAsObservable()
                .Subscribe(_ => _mainMenu.NavigateToWeaponSelection())
                .AddTo(gameObject);
        }
    }
}