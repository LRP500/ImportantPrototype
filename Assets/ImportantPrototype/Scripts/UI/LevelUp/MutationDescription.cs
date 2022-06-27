using System.Collections.Generic;
using ImportantPrototype.Mutations;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI
{
    public class MutationDescription : Element
    {
        [SerializeField]
        private GeneItem _genePrefab;

        [SerializeField]
        private Transform _geneContainer;

        [SerializeField]
        private MutationReactiveVariable _hoveredMutation;
        
        private readonly List<GeneItem> _genes = new ();

        public override void Initialize()
        {
            _hoveredMutation.Property
                .Subscribe(Refresh)
                .AddTo(this);
        }

        private void Refresh(Mutation mutation)
        {
            if (mutation == null) return;
            SetMutation(mutation);
        }

        private void SetMutation(Mutation mutation)
        {
            Clear();

            var genes = mutation.GetAllGenes();
            for (int i = 0; i < genes.Count; i++)
            {
                var item = CreateGeneItem(genes[i]);
                _genes.Add(item);
            }
        }

        private GeneItem CreateGeneItem(Gene gene)
        {
            var item = Instantiate(_genePrefab, _geneContainer);
            item.Initialize(gene);
            return item;
        }

        public override void Clear()
        {
            for (int i = 0; i < _genes.Count; i++)
            {
                var gene = _genes[i];
                Destroy(gene.gameObject);
            }

            _genes.Clear();
        }
    }
}