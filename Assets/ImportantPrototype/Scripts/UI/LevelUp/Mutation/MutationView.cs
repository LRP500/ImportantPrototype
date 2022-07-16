using System;
using ImportantPrototype.Mutations;
using ImportantPrototype.Tools.UI;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.UI
{
    public class MutationView : ListItemView<Mutation>
    {
        [SerializeField]
        private TextMeshProUGUI _name;

        [SerializeField]
        private Toggle _toggle;

        public Mutation Mutation { get; private set; }

        public override void Bind(Mutation mutation)
        {
            Mutation = mutation;
            Refresh();
        }

        public IObservable<Mutation> ObserveSelect()
        {
            return _toggle
                .OnValueChangedAsObservable()
                .WhereTrue()
                .Select(_ => Mutation);
        }

        public override void Refresh()
        {
            _name.SetText(Mutation.Data.Name);
        }
    }
}