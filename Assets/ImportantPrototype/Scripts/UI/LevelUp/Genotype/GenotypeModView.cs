using ImportantPrototype.Mutations.Mods;
using ImportantPrototype.Tools.UI;
using TMPro;
using UnityEngine;

namespace ImportantPrototype.UI
{
    /// <summary>
    /// Displays a single genotype modifier.
    /// </summary>
    public class GenotypeModView : ListItemView<GenotypeMod>
    {
        [SerializeField]
        private TextMeshProUGUI _description;
        
        public override void Bind(GenotypeMod data)
        {
            _description.SetText(data.GetDescription());
        }
    }
}