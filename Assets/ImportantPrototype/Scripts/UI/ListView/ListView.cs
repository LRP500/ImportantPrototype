using UniRx;
using UnityEngine;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.Tools.UI
{
    public abstract class ListView<T> : Element
    {
        [SerializeField]
        private ListItemView<T> _itemViewPrefab;

        [SerializeField]
        private Transform _itemViewContainer;

        private IReadOnlyReactiveCollection<T> _data;
        private readonly ReactiveCollection<ListItemView> _itemViews = new ();

        public void Bind(IReadOnlyReactiveCollection<T> collection)
        {
            _data = collection;
        }
        
        protected override void OnShow()
        {
            CreateViews();
        }

        protected override void OnHide()
        {
            ClearViews();
        }

        private void CreateViews()
        {
            foreach (var item in _data)
            {
                var view = CreateView(item);
                _itemViews.Add(view);
            }
        }

        public override void ClearViews()
        {
            for (int i = 0; i < _itemViews.Count; i++)
            {
                Destroy(_itemViews[i].gameObject);
            }
            
            _itemViews.Clear();
        }

        private ListItemView CreateView(T mod)
        {
            var instance = Instantiate(_itemViewPrefab, _itemViewContainer);
            instance.Bind(mod);
            return instance;
        }
    }
}
