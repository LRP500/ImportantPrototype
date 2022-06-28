using System.Collections.Generic;
using ImportantPrototype.Mutations;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI
{
    public class MutationInfoDisplay : Element
    {
        [SerializeField]
        private GeneItem _genePrefab;

        [SerializeField]
        private GenotypeModItem _genotypeModPrefab;
        
        [SerializeField]
        private Transform _itemContainer;

        [SerializeField]
        private MutationReactiveVariable _hoveredMutation;
        
        private readonly List<GameObject> _items = new ();

        public override void Initialize()
        {
            _hoveredMutation.Property
                .Subscribe(Refresh)
                .AddTo(this);
        }

        private void Refresh(Mutation mutation)
        {
            if (mutation == null) return;
            Clear();
            SetMutation(mutation.GetAllGenes());
            SetGenotypeMod(mutation.GenotypeMod);
        }

        private void SetMutation(IReadOnlyList<Gene> genes)
        {
            for (int i = 0; i < genes.Count; i++)
            {
                var item = CreateGeneItem(genes[i]);
                _items.Add(item.gameObject);
            }
        }

        private void SetGenotypeMod(GenotypeMod mod)
        {
            var item = CreateGenotypeModItem(mod);
            _items.Add(item.gameObject);
        }
        
        private GeneItem CreateGeneItem(Gene gene)
        {
            var item = Instantiate(_genePrefab, _itemContainer);
            item.Initialize(gene);
            return item;
        }

        private GenotypeModItem CreateGenotypeModItem(GenotypeMod mod)
        {
            var item = Instantiate(_genotypeModPrefab, _itemContainer);
            item.Bind(mod);
            return item;
        }
        
        public override void Clear()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                var gene = _items[i];
                Destroy(gene);
            }

            _items.Clear();
        }
    }
}