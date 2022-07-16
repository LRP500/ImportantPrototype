using ImportantPrototype.Gameplay;

namespace ImportantPrototype.Scripts.Damageable.Effects
{
    public class DestroyOnDeath : DeathEffect
    {
        protected override void Trigger()
        {
            Destroy(gameObject);
        }
    }
}