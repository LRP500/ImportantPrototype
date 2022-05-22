using ImportantPrototype.System;
using UnityEngine;
using UnityTools.Runtime.ECA.Actions;

namespace ImportantPrototype.Items.Pickups
{
    [CreateAssetMenu(menuName = ContextMenuPath.Items + "Pickup")]
    public class PickupItemData : ScriptableObject
    {
        [SerializeField]
        private string _name;

        [Multiline]
        [SerializeField]
        private string _description;

        [SerializeField]
        private ScriptableAction _onPick;
        
        public string Name => _name;
        public string Description => _description;
        public ScriptableAction OnPick => _onPick;
    }
}
