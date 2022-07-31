using System.Collections.Generic;
using System.Linq;
using ImportantPrototype.Gameplay.Mutations.Genes;
using ImportantPrototype.Gameplay.Mutations.Mods;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.Gameplay.Mutations
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
        public void Roll()
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
        
        public void OnPick(GameplayContext context)
        {
            ApplyGenes(context);
        }

        public void Rollback(GameplayContext context)
        {
            var genes = new List<Gene>(PositiveGenes);
            genes.AddRange(NegativeGenes);

            for (int i = 0; i < genes.Count; i++)
            {
                genes[i].Rollback(context);
            }
        }
        
        private void ApplyGenes(GameplayContext context)
        {
            var genes = new List<Gene>(PositiveGenes);
            genes.AddRange(NegativeGenes);

            for (int i = 0; i < genes.Count; i++)
            {
                genes[i].Apply(context);
            }
        }

        public IEnumerable<Gene> GetAllGenes()
        {
            return PositiveGenes.Concat(NegativeGenes);
        }
    }
}