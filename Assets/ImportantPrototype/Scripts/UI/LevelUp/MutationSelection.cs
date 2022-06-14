﻿using System;
using System.Collections.Generic;
using ImportantPrototype.Mutations;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI
{
    public class MutationSelection : Element
    {
        [SerializeField]
        private MutationGridItem _mutationPrefab;
        
        [SerializeField]
        private GridLayoutGroup _gridLayout;

        private Action<Mutation> _callback;
        private readonly List<MutationGridItem> _mutations = new ();

        private void OnMutationSelected(Mutation mutation)
        {
            _callback.Invoke(mutation);
        }

        public void Open(IEnumerable<Mutation> items, Action<Mutation> callback)
        {
            _callback = callback;
            CreateItems(items);
            Show();
        }

        private void CreateItems(IEnumerable<Mutation> items)
        {
            foreach (var mutation in items)
            {
                var item = CreateItem(mutation);
                _mutations.Add(item);
            } 
        }
        
        private MutationGridItem CreateItem(Mutation mutation)
        {
            var item = Instantiate(_mutationPrefab, _gridLayout.transform);
            item.Bind(mutation);
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