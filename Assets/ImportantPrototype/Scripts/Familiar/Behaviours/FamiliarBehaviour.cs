using UnityEngine;

namespace ImportantPrototype.Gameplay.Familiars
{
    public abstract class FamiliarBehaviour : ScriptableObject
    {
        public abstract void Initialize(Familiar familiar);
        public abstract void Refresh(Familiar familiar);
    }
}