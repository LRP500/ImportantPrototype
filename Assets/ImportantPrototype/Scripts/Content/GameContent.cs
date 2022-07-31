using System.Collections.Generic;
using ImportantPrototype.Content;
using ImportantPrototype.Gameplay.Mutations;
using ImportantPrototype.Weapons;
using UnityEngine;
using UnityTools.Runtime;
using ContextMenuPath = ImportantPrototype.System.ContextMenuPath;

namespace ImportantPrototype.Gameplay
{
    [CreateAssetMenu(menuName = ContextMenuPath.Content + "Game Content")]
    public class GameContent : ScriptableObjectSingleton<GameContent>
    {
        [SerializeField]
        private WeaponAssetListVariable _weapons;

        [SerializeField]
        private MutationAssetListVariable _mutations;
        
        public IEnumerable<WeaponData> Weapons => _weapons.Items;
        public IEnumerable<MutationData> Mutations => _mutations.Items;
    }
}