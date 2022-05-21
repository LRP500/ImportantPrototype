using ImportantPrototype.System;
using UnityEngine;

namespace ImportantPrototype.Stats
{
    [CreateAssetMenu(menuName = ContextMenuPath.Stats + "Stat Type")]
    public class StatType : ScriptableObject
    {
        [SerializeField]
        private string _id;

        [SerializeField]
        private string _name;

        [Multiline]
        [SerializeField]
        private string _description;
        
        public string Id => _id;
    }
}