using ImportantPrototype.Stats;
using UnityEngine;

namespace ImportantPrototype.Characters
{
    public class CharacterStats : MonoBehaviour
    {
        public ModifiableStat Health { get; private set; }

        private void Awake()
        {
            Health = new ModifiableStat("Health", 100);
        }
    }
}
