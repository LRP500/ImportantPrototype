using System.Collections.Generic;
using ImportantPrototype.Content;
using ImportantPrototype.Mutations;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityTools.Runtime.ECA.Events;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI
{
    public class LevelUpScreen : Element
    {
        [SerializeField]
        private MutationGridItem _mutationPrefab;
        
        [SerializeField]
        private GridLayoutGroup _gridLayout;
        
        [SerializeField]
        private ScriptableEvent _mutationSelectedEvent;

        private Mutation _selectedMutation;
        
        private readonly List<MutationGridItem> _mutations = new ();
        
        private void OnMutationSelected(Mutation mutation)
        {
            _selectedMutation = mutation;
            // _mutationSelectedEvent.Raise();
            Hide();
            PauseManager.Resume();
        }

        protected override void OnShow()
        {
            CreateMutations();
        }

        private void CreateMutations()
        {
            foreach (var mutation in GameContent.Instance.Mutations)
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
        
        protected override void OnHide()
        {
            Clear();
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