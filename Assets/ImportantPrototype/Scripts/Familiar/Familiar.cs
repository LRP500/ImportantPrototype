using ImportantPrototype.Characters;
using UnityEngine;

namespace ImportantPrototype.Gameplay.Familiars
{
    public class Familiar : MonoBehaviour
    {
        [SerializeField]
        private Damager _damager;
        
        public Player Owner { get; private set; }
        public FamiliarData Data { get; private set; }
        public FamiliarBehaviour Behaviour { get; private set; }

        public static Familiar FromData(FamiliarData data)
        {
            var instance = Instantiate(data.Prefab);
            instance.Behaviour = Instantiate(data.Behaviour);
            instance.Data = data;
            return instance;
        }

        public void Initialize(Player player)
        {
            Owner = player;
            Behaviour.Initialize(this);
            _damager.SetDamage(Data.Damage);
        }

        public void Refresh()
        {
            Behaviour.Refresh(this);
        }
    }
}
