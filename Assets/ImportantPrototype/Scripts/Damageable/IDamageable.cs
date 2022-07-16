using ImportantPrototype.Interfaces;
using ImportantPrototype.Stats;
using UniRx;

namespace ImportantPrototype.Gameplay
{
    public interface IDamageable
    {
        Attribute Health { get; }
        void Damage(IDamager damager);
        
        public ISubject<Unit> OnDeath { get; }
        public ISubject<float> OnDamageTaken { get; }
    }
}