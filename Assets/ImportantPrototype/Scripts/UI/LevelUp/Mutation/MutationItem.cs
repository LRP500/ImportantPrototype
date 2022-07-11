using System;
using ImportantPrototype.Mutations;
using ImportantPrototype.Tools.UI;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.UI
{
    public class MutationItem : ListItemView<Mutation>, IPointerEnterHandler
    {
        [SerializeField]
        private TextMeshProUGUI _name;

        [SerializeField]
        private Toggle _toggle;

        [SerializeField]
        private MutationReactiveVariable _hoveredMutation;

        private Mutation _mutation;

        public override void Bind(Mutation mutation)
        {
            _mutation = mutation;
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
            _name.SetText(_mutation.Data.Name);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _hoveredMutation.SetValue(_mutation);
        }
    }
}