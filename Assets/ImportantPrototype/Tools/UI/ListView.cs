using UniRx;
using UnityEngine;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.Tools.UI
{
    public abstract class ListView<T> : Element
    {
        [SerializeField]
        private ListItemView<T> _itemPrefab;

        [SerializeField]
        private Transform _itemContainer;

        private IReadOnlyReactiveCollection<T> _data;
        private readonly ReactiveCollection<ListItemView> _views = new ();

        private readonly CompositeDisposable _disposables = new ();
        
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
            _disposables.Clear();
        }

        private void CreateViews()
        {
            foreach (var item in _data)
            {
                var view = CreateView(item);
                _views.Add(view);
            }
        }

        public override void ClearViews()
        {
            for (int i = 0; i < _views.Count; i++)
            {
                Destroy(_views[i].gameObject);
            }
            
            _views.Clear();
        }

        private ListItemView CreateView(T mod)
        {
            var instance = Instantiate(_itemPrefab, _itemContainer);
            instance.BindData(mod);
            return instance;
        }
    }
}
