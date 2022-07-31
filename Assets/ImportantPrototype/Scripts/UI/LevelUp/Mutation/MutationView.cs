using System;
using ImportantPrototype.Gameplay.Mutations;
using ImportantPrototype.Tools.UI;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.UI
{
    public class MutationView : ListItemView<Mutation>, IPointerClickHandler
    {
        [SerializeField]
        private TextMeshProUGUI _name;

        public Mutation Mutation { get; private set; }

        private readonly ISubject<Mutation> OnSelect = new Subject<Mutation>();

        public override void Bind(Mutation mutation)
        {
            Mutation = mutation;
            Refresh();
        }

        public override void Refresh()
        {
            _name.SetText(Mutation.Data.Name);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnSelect.OnNext(Mutation);
        }
        
        public IObservable<Mutation> ObserveSelect()
        {
            return OnSelect.WhereNotNull();
        }
    }
}