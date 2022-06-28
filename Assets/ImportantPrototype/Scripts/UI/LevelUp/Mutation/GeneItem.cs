using ImportantPrototype.Mutations;
using TMPro;
using UnityEngine;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI
{
    public class GeneItem : Element
    {
        [SerializeField]
        private TextMeshProUGUI _description;

        public void Initialize(Gene gene)
        {
            _description.SetText(gene.ToString());
        }
    }
}