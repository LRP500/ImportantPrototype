using System;
using ImportantPrototype.Mutations;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityTools.Runtime.Extensions;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI
{
    public class MutationItem : Element, IPointerEnterHandler
    {
        [SerializeField]
        private TextMeshProUGUI _name;

        [SerializeField]
        private Toggle _toggle;

        [SerializeField]
        private MutationReactiveVariable _hoveredMutation;

        private Mutation _mutation;

        public override void Initialize()
        {
            _toggle.group = GetComponentInParent<ToggleGroup>();
        }

        public void Bind(Mutation gene)
        {
            _mutation = gene;
            Refresh();
        }

        public IObservable<Mutation> ObserveSelect()
        {
            return _toggle
                .OnValueChangedAsObservable()
                .WhereTrue()
                .Select(_ => _mutation);
        }

        public override void Refresh()
        {
            _name.SetText(_mutation.Name);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _hoveredMutation.SetValue(_mutation);
        }
    }
}