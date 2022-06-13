using System;
using ImportantPrototype.Mutations;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityTools.Runtime.Extensions;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI
{
    public class MutationGridItem : Element
    {
        [SerializeField]
        private TextMeshProUGUI _name;

        [SerializeField]
        private TextMeshProUGUI _description;
        
        [SerializeField]
        private Toggle _toggle;
        
        private Mutation _mutation;

        public override void Initialize()
        {
            _toggle.group = GetComponentInParent<ToggleGroup>();
        }

        public void Bind(Mutation mutation)
        {
            _mutation = mutation;
            Refresh();
        }

        public IObservable<Mutation> ObserveSelect()
        {
            return _toggle.OnToggleOn().Select(_ => _mutation);
        }

        public override void Refresh()
        {
            _name.SetText(_mutation.Name);
            _description.SetText(_mutation.Description);
        }

        public void Select()
        {
            _toggle.isOn = true;
        }
    }
}