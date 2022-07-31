﻿using ImportantPrototype.Gameplay.Mutations.Genes;
using TMPro;
using UnityEngine;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI
{
    public class GeneView : Element
    {
        [SerializeField]
        private TextMeshProUGUI _description;

        public void Initialize(Gene gene)
        {
            _description.SetText(gene.ToString());
        }
    }
}