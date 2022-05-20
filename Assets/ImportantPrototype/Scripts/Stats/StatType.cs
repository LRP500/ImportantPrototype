using UnityEngine;

namespace ImportantPrototype.Stats
{
    // [CreateAssetMenu(menuName = ContextMenuPath.Stats + "/Stat Type")]
    public class StatType : ScriptableObject
    {
        [SerializeField]
        private string _name;
    }
}