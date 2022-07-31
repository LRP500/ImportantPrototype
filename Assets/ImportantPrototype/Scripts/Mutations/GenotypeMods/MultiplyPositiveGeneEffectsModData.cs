using ImportantPrototype.System;
using UnityEngine;

namespace ImportantPrototype.Gameplay.Mutations.Mods
{
    [CreateAssetMenu(menuName = ContextMenuPath.GenotypeMods + "Multiply Positive Gene Effects")]
    public class MultiplyPositiveGeneEffectsModData : MultiplyGeneEffectModData
    {
        public override GenotypeMod Create()
        {
            return new MultiplyPositiveGeneEffectsMod(Duration, GetValue());
        }
    }
}