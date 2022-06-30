using System.Globalization;
using ImportantPrototype.Stats;
using TMPro;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI.HUD
{
    public class AttributeItemUI : Element
    {
        [SerializeField]
        private TextMeshProUGUI _statName;

        [SerializeField]
        private TextMeshProUGUI _statValue;
        
        private Attribute _attribute;
        
        public void Bind(Attribute stat)
        {
            _attribute = stat;
            _attribute.Property
                .Subscribe(Refresh)
                .AddTo(gameObject);
            _statName
                .SetText($"{stat.Info.Name}:");
        }

        private void Refresh(float value)
        {
            _statValue.SetText(value.ToString(CultureInfo.InvariantCulture));
        }
    }
}