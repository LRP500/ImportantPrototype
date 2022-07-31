using ImportantPrototype.Gameplay.Mutations;
using UnityEngine;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI.LevelUp
{
    public class LevelUpRerollModView : CompositeElement
    {
        [SerializeField]
        private MutationReactiveVariable _selectedMutation;
        
        protected override void OnShow()
        {
            base.OnShow();
            _selectedMutation.Clear();
        }
    }
}