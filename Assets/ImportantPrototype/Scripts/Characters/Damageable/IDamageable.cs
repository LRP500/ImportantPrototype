using ImportantPrototype.Stats;

namespace ImportantPrototype.Interfaces
{
    public interface IDamageable
    {
        ModifiableStat Health { get; }
        void Damage(IDamager damager);
    }
}