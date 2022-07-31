using ImportantPrototype.System;
using UnityEngine;

namespace ImportantPrototype.Gameplay.Mutations.Mods
{
    [CreateAssetMenu(menuName = ContextMenuPath.GenotypeMods + "Multiply All Gene Effects")]
    public class MultiplyAllGeneEffectsModData : MultiplyGeneEffectModData
    {
        public override GenotypeMod Create()
        {
            return new MultiplyAllGeneEffectsMod(Duration, GetValue());
        }
    }
}