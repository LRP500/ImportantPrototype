using ImportantPrototype.Interfaces;

namespace ImportantPrototype.Characters
{
    public class CharacterDamageable : Damageable
    {
        private Character _character;

        private void Awake()
        {
            _character = GetComponent<Character>();
        }

        private void Start()
        {
            Health = _character.Stats.Health;
        }

        public override void Damage(IDamager damager)
        {
            Health.Remove(damager.Damage);
            
            if (Health.Value.Value <= 0)
            {
                _character.OnDeath();
            }
        }
    }
}