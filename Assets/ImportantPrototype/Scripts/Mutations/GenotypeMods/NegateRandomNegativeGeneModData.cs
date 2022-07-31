using ImportantPrototype.System;
using UnityEngine;

namespace ImportantPrototype.Gameplay.Mutations.Mods
{
    [CreateAssetMenu(menuName = ContextMenuPath.GenotypeMods + "Negate Random Negative Gene")]
    public class NegateRandomNegativeGeneModData : GenotypeModData
    {
        public override GenotypeMod Create()
        {
            return new NegateRandomNegativeGeneMod(Duration);
        }
    }
}