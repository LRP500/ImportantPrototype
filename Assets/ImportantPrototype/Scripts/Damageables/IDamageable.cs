using ImportantPrototype.Interfaces;
using UniRx;

namespace ImportantPrototype.Gameplay
{
    public interface IDamageable
    {
        double Health { get; }
        void Damage(IDamager damager);
        
        public ISubject<Unit> OnDeath { get; }
        public ISubject<float> OnDamageTaken { get; }
    }
}