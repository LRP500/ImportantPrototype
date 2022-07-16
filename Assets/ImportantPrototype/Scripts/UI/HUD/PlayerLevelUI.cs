using ImportantPrototype.Characters;
using TMPro;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.Extensions;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI.HUD
{
    public class PlayerLevelUI : Element
    {
        [SerializeField]
        private PlayerReactiveVariable _player;

        [SerializeField]
        private TextMeshProUGUI _text;

        public override void Initialize()
        {
            _player.Value.Stats
                .ObserveAttribute(CharacterStatType.Level)
                .Subscribe(Refresh)
                .AddToDisable(this);
        }
        
        private void Refresh(float level)
        {
            _text.SetText(((int) level + 1).ToString());
        }
    }
}