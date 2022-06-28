using ImportantPrototype.Mutations;
using TMPro;
using UnityEngine;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI
{
    /// <summary>
    /// Displays a single genotype modifier.
    /// </summary>
    public class GenotypeModItem : Element
    {
        [SerializeField]
        private TextMeshProUGUI _description;
        
        public void Bind(GenotypeMod mod)
        {
            _description.SetText(mod.GetDescription());
        }
    }
}