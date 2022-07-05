using System.Collections.Generic;
using System.Linq;
using ImportantPrototype.Characters;
using ImportantPrototype.Mutations.Mods;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.Mutations
{
    public sealed class Mutation
    {
        public MutationData Data { get; private set; }
        
        public List<Gene> PositiveGenes { get; private set; }
        public List<Gene> NegativeGenes  { get; private set; }

        public GenotypeMod GenotypeMod { get; private set; }
        
        public static Mutation FromData(MutationData data)
        {
            var hasMod = UnityEngine.Random.value <= data.ModChance;
            var mod = hasMod ? data.GenotypeMods.ToList().Random()?.Create() : null;
            
            return new Mutation
            {
                Data = data,
                PositiveGenes = data.PositiveGenes.ToList(),
                NegativeGenes = data.NegativeGenes.ToList(),
                GenotypeMod = mod
            };
        }
        
        public void OnPick(Player player)
        {
            ApplyGenes(player);
        }

        private void ApplyGenes(Player player)
        {
            var genes = new List<Gene>(PositiveGenes);
            genes.AddRange(NegativeGenes);

            for (int i = 0; i < genes.Count; i++)
            {
                genes[i].Apply(player);
            }
        }

        public IEnumerable<Gene> GetAllGenes()
        {
            return PositiveGenes.Concat(NegativeGenes);
        }
    }
}