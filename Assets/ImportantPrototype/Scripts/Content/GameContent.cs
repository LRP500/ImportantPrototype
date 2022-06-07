using System.Collections.Generic;
using ImportantPrototype.Weapons;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityTools.Runtime;
using ContextMenuPath = ImportantPrototype.System.ContextMenuPath;

namespace ImportantPrototype.Content
{
    [CreateAssetMenu(menuName = ContextMenuPath.Content + "Game Content")]
    public class GameContent : ScriptableObjectSingleton<GameContent>
    {
        [InlineEditor]
        [SerializeField]
        private WeaponAssetListVariable _weapons;

        public IReadOnlyList<WeaponData> Weapons => _weapons.Items;
    }
}