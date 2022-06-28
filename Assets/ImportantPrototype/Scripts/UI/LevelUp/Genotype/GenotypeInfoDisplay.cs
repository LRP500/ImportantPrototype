using System.Collections.Generic;
using ImportantPrototype.Mutations;
using UnityEngine;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI
{
    /// <summary>
    /// Display current genotype modifiers.
    /// </summary>
    public class GenotypeInfoDisplay : Element
    {
        [SerializeField]
        private GenotypeModItem _itemPrefab;

        [SerializeField]
        private Transform _itemContainer;
     
        [SerializeField]
        private MutationManager _mutationManager;

        private readonly List<GenotypeModItem> _items = new ();
        
        protected override void OnShow()
        {
            CreateItems(_mutationManager.GenotypeMods);
        }

        private void CreateItems(IEnumerable<GenotypeMod> mods)
        {
            foreach (var mod in mods)
            {
                var item = CreateItem(mod);
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

        private GenotypeModItem CreateItem(GenotypeMod mod)
        {
            var instance = Instantiate(_itemPrefab, _itemContainer);
            instance.Bind(mod);
            return instance;
        }
    }
}