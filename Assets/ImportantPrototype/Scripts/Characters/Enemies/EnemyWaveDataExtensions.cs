using System.Linq;
using UnityTools.Runtime.Utils;

namespace ImportantPrototype.Characters.Enemies
{
    public static class EnemyWaveDataExtensions
    {
        public static EnemyData GetRandomItem(this EnemyWaveData wave)
        {
            var weights = wave.Items.Select(x => x.weight).ToArray();
            var result = RandomUtils.GetRandomWeightedIndex(weights);
            return wave.Items[result].enemy;
        }
    }
}