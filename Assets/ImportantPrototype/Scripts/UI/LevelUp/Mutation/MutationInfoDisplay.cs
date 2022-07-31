using System.Collections.Generic;
using ImportantPrototype.Gameplay.Mutations;
using ImportantPrototype.Gameplay.Mutations.Genes;
using ImportantPrototype.Gameplay.Mutations.Mods;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI
{
    public class MutationInfoDisplay : Element
    {
        [SerializeField]
        private GeneView _genePrefab;

        [SerializeField]
        private GenotypeModView _genotypeModPrefab;
        
        [SerializeField]
        private Transform _itemContainer;

        [SerializeField]
        private MutationReactiveVariable _hoveredMutation;
        
        private readonly List<GameObject> _items = new ();

        public override void Initialize()
        {
            _hoveredMutation.Property
                .Subscribe(_ => Refresh())
                .AddTo(this);
        }

        public override void Refresh()
        {
            ClearViews();

            var mutation = _hoveredMutation.Property.Value;
            if (mutation == null) return;
            
            SetMutation(mutation.GetAllGenes());
            SetGenotypeMod(mutation.GenotypeMod);
        }

        protected override void OnShow()
        {
            base.OnShow();
            Refresh();
        }

        private void SetMutation(IEnumerable<Gene> genes)
        {
            foreach (var gene in genes)
            {
                var item = CreateGeneItem(gene);
                _items.Add(item.gameObject);
            }
        }

        private void SetGenotypeMod(GenotypeMod mod)
        {
            if (mod == null) return;
            var item = CreateGenotypeModItem(mod);
            _items.Add(item.gameObject);
        }
        
        private GeneView CreateGeneItem(Gene gene)
        {
            var item = Instantiate(_genePrefab, _itemContainer);
            item.Initialize(gene);
            return item;
        }

        private GenotypeModView CreateGenotypeModItem(GenotypeMod mod)
        {
            var item = Instantiate(_genotypeModPrefab, _itemContainer);
            item.Bind(mod);
            return item;
        }
        
        public override void ClearViews()
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