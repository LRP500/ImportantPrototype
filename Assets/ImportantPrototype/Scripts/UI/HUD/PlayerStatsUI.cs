using System.Collections.Generic;
using System.Linq;
using ImportantPrototype.Characters;
using ImportantPrototype.Stats;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityTools.Runtime.Extensions;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI.HUD
{
    public class PlayerStatsUI : Element
    {
        [SerializeField]
        private PlayerStatsItemUI _itemPrefab;

        [SerializeField]
        private Transform _itemContainer;

        [SerializeField]
        private PlayerReactiveVariable _player;

        [AssetList]
        [SerializeField]
        private List<CharacterStatInfo> _stats;
        
        private readonly List<PlayerStatsItemUI> _items = new ();

        public override void Initialize()
        {
            _player.Property
                .WhereNotNull()
                .TakeFirst()
                .Subscribe(player =>
                {
                    var attributes = GetAttributes(player);
                    CreateItems(attributes);
                    LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
                })
                .AddTo(gameObject);
        }

        private IEnumerable<Attribute> GetAttributes(Character player)
        {
            return _stats.Select(x => player.Stats.Collection.Get<Attribute>(x.Id));
        }
        
        private void CreateItems(IEnumerable<Attribute> stats)
        {
            foreach (var stat in stats)
            {
                var item = CreateItem(stat);
                _items.Add(item);
            }
        }
        
        protected override void OnHide()
        {
            Clear();
        }

        public override void Clear()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                Destroy(_items[i].gameObject);
            }
            
            _items.Clear();
        }

        private PlayerStatsItemUI CreateItem(Attribute stat)
        {
            var instance = Instantiate(_itemPrefab, _itemContainer);
            instance.Bind(stat);
            return instance;
        }
    }
}
