using System.Collections.Generic;
using ImportantPrototype.Mutations;
using ImportantPrototype.Weapons;
using UnityEngine;
using UnityTools.Runtime;
using ContextMenuPath = ImportantPrototype.System.ContextMenuPath;

namespace ImportantPrototype.Content
{
    [CreateAssetMenu(menuName = ContextMenuPath.Content + "Game Content")]
    public class GameContent : ScriptableObjectSingleton<GameContent>
    {
        [SerializeField]
        private WeaponAssetListVariable _weapons;

        [SerializeField]
        private MutationAssetListVariable _mutations;
        
        public IEnumerable<WeaponData> Weapons => _weapons.Items;
        public IEnumerable<Mutation> Mutations => _mutations.Items;
    }
}