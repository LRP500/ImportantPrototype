using ImportantPrototype.Stats;

namespace ImportantPrototype.Interfaces
{
    public interface IDamageable
    {
        Attribute Health { get; }
        void Damage(IDamager damager);
    }
}