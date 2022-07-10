using System.Collections.Generic;
using System.Linq;
using ImportantPrototype.Characters;
using ImportantPrototype.Mutations.Mods;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.Mutations
{
    public sealed class Mutation
    {
        public MutationData Data { get; }
        public GenotypeMod GenotypeMod { get; private set; }
        public List<Gene> PositiveGenes { get; private set; }
        public List<Gene> NegativeGenes  { get; private set; }
        
        public static Mutation FromData(MutationData data)
        {
            var mutation = new Mutation(data);
            mutation.Initialize();
            mutation.Roll();
            return mutation;
        }

        private Mutation(MutationData data)
        {
            Data = data;
        }

        /// <summary>
        /// Resets to its default state.
        /// </summary>
        private void Initialize()
        {
            PositiveGenes = Data.PositiveGenes.Select(x => x.Clone()).ToList();
            NegativeGenes = Data.NegativeGenes.Select(x => x.Clone()).ToList();
            GenotypeMod?.Reset();
        }

        public void Reset()
        {
            Initialize();
        }
        
        /// <summary>
        /// Rerolls all randomizable attributes.
        /// </summary>
        private void Roll()
        {
            GenotypeMod = RollMod(Data);
        }

        /// <summary>
        /// Generates a random genotype mod.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static GenotypeMod RollMod(MutationData data)
        {
            var hasMod = UnityEngine.Random.value <= data.ModChance;
            return hasMod ? data.GenotypeMods.ToList().Random()?.Create() : null;
        }
        
        public void OnPick(Player player)
        {
            ApplyGenes(player);
        }

        public void Rollback(Player player)
        {
            var genes = new List<Gene>(PositiveGenes);
            genes.AddRange(NegativeGenes);

            for (int i = 0; i < genes.Count; i++)
            {
                genes[i].Rollback(player);
            }
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