using System;
using System.Collections.Generic;
using System.Linq;
using ImportantPrototype.Mutations;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityTools.Runtime.Extensions;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI
{
    public class MutationSelection : CompositeElement
    {
        [SerializeField]
        private MutationItem _mutationPrefab;

        [SerializeField]
        private GridLayoutGroup _gridLayout;

        [SerializeField]
        private MutationReactiveVariable _hoveredMutation;
        
        private Action<Mutation> _callback;
        private List<Mutation> _choices = new ();
        private readonly List<MutationItem> _mutations = new ();
        
        private void OnMutationSelected(Mutation gene)
        {
            _callback.Invoke(gene);
        }
        
        public void Open(IEnumerable<Mutation> choices, Action<Mutation> callback)
        {
            _callback = callback;
            _choices = choices.ToList();
            _hoveredMutation.SetValue(_choices[0]);
            Show();
        }

        protected override void OnShow()
        {
            base.OnShow();
            CreateItems();
        }

        protected override void OnHide()
        {
            base.OnHide();
            Clear();
        }

        private void CreateItems()
        {
            for (int i = 0; i < _choices.Count; i++)
            {
                var mutation = _choices[i];
                var item = CreateItem(mutation);
                _mutations.Add(item);
            }
        }
        
        private MutationItem CreateItem(Mutation gene)
        {
            var item = Instantiate(_mutationPrefab, _gridLayout.transform);
            item.Bind(gene);
            item.ObserveSelect()
                .Subscribe(OnMutationSelected)
                .AddTo(gameObject);
            return item;
        }
        
        public override void Clear()
        {
            foreach (var mutation in _mutations)
            {
                Destroy(mutation.gameObject);
            }
            
            _mutations.Clear();
        }
    }
}