using ImportantPrototype.Characters;
using UnityEngine;

namespace ImportantPrototype.Mutations
{
    public abstract class Mutation : ScriptableObject
    {
        [SerializeField]
        private string _name;

        [Multiline]
        [SerializeField]
        private string _description;

        public string Name => _name;
        public string Description => _description;
        
        public abstract void OnPick(Player player);
    }
}
