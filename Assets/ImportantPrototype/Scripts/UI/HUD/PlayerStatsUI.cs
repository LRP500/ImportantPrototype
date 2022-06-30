using System.Collections.Generic;
using System.Linq;
using ImportantPrototype.Characters;
using ImportantPrototype.Stats;
using ImportantPrototype.Weapons;
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
        private AttributeItemUI _itemPrefab;

        [SerializeField]
        private Transform _itemContainer;

        [SerializeField]
        private PlayerReactiveVariable _player;

        [AssetList]
        [SerializeField]
        private List<CharacterStatInfo> _characterStats;
        
        [AssetList]
        [SerializeField]
        private List<WeaponStatInfo> _weaponStats;
        
        private readonly List<AttributeItemUI> _items = new ();

        public override void Initialize()
        {
            _player.Property
                .WhereNotNull()
                .Zip(_player.Value.Weapon.WhereNotNull(), (player, _) => player)
                .TakeFirst()
                .Subscribe(player =>
                {
                    CreateItems(GetAttributes(player));
                    LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
                })
                .AddTo(gameObject);
        }

        private IEnumerable<Attribute> GetAttributes(Player player)
        {
            var weapon = player.Weapon.Value;
            var playerAttributes = _characterStats.Select(x => player.Stats.Collection.Get<Attribute>(x.Id));
            var weaponAttributes = _weaponStats.Select(x => weapon.Stats.Get<Attribute>(x.Id));
            return playerAttributes.Concat(weaponAttributes);
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

        private AttributeItemUI CreateItem(Attribute stat)
        {
            var instance = Instantiate(_itemPrefab, _itemContainer);
            instance.Bind(stat);
            return instance;
        }
    }
}
