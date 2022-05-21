using ImportantPrototype.Stats;
using UnityEngine;

namespace ImportantPrototype.Characters
{
    public class CharacterStats : MonoBehaviour
    {
        public ModifiableStat MaxHealth { get; private set; }
        public ModifiableStat Health { get; private set; }

        private void Awake()
        {
            MaxHealth = new ModifiableStat(3);
            Health = new ModifiableStat(MaxHealth.Value.Value);
        }
    }
}