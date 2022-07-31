using ImportantPrototype.System;
using UnityEngine;

namespace ImportantPrototype.Gameplay.Mutations.Mods
{
    [CreateAssetMenu(menuName = ContextMenuPath.GenotypeMods + "Multiply Negative Gene Effects")]
    public class MultiplyNegativeGeneEffectsModData : MultiplyGeneEffectModData
    {
        public override GenotypeMod Create()
        {
            return new MultiplyNegativeGeneEffectsMod(Duration, GetValue());
        }
    }
}