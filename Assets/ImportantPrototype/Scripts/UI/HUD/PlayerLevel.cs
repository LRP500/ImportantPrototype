using Extensions;
using ImportantPrototype.Characters;
using TMPro;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI.HUD
{
    public class PlayerLevel : Element
    {
        [SerializeField]
        private PlayerReactiveVariable _player;

        [SerializeField]
        private TextMeshProUGUI _text;

        public override void Initialize()
        {
            _player.Value.Stats
                .ObserveValueChanged("level")
                .Subscribe(Refresh)
                .AddToDisable(this);
        }
        
        private void Refresh(float level)
        {
            _text.SetText(((int) level + 1).ToString());
        }
    }
}
