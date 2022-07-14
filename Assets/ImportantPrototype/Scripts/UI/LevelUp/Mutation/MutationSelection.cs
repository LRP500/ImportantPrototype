using System;
using System.Collections.Generic;
using System.Linq;
using ImportantPrototype.Mutations;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI
{
    public class MutationSelection : CompositeElement
    {
        [SerializeField]
        private MutationView _mutationPrefab;

        [SerializeField]
        private GridLayoutGroup _gridLayout;

        [SerializeField]
        private MutationManager _mutationManager;
        
        [SerializeField]
        private MutationReactiveListVariable _mutationChoices;
        
        [SerializeField]
        private MutationReactiveVariable _hoveredMutation;

        [SerializeField]
        private GenotypeModListView _genotypeModList;
        
        private Action<Mutation> _mutationSelectedCallback;

        private List<Mutation> _choices = new ();
        private readonly List<MutationView> _mutations = new ();
        
        private void OnMutationSelected(Mutation gene)
        {
            _mutationSelectedCallback.Invoke(gene);
        }
        
        public void Open(Action<Mutation> callback)
        {
            _mutationSelectedCallback = callback;
            _genotypeModList.Bind(_mutationManager.GenotypeMods);
            Show();
        }

        public override void Refresh()
        {
            _choices = _mutationChoices.Values.ToList();
            _hoveredMutation.SetValue(_choices[0]);
            ClearViews();
            CreateItems();
            base.Refresh();
        }

        protected override void OnShow()
        {
            base.OnShow();
            Refresh();
        }

        protected override void OnHide()
        {
            base.OnHide();
            ClearViews();
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
        
        private MutationView CreateItem(Mutation gene)
        {
            var item = Instantiate(_mutationPrefab, _gridLayout.transform);
            item.Bind(gene);
            item.ObserveSelect()
                .Subscribe(OnMutationSelected)
                .AddTo(gameObject);
            return item;
        }
        
        public override void ClearViews()
        {
            foreach (var mutation in _mutations)
            {
                Destroy(mutation.gameObject);
            }
            
            _mutations.Clear();
        }
    }
}