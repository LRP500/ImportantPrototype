using ImportantPrototype.Managers;
using ImportantPrototype.System;
using UniRx;
using UnityEngine;

namespace ImportantPrototype.Gameplay.Familiars
{
    [CreateAssetMenu(menuName = ContextMenuPath.Familiars + "Familiar Manager")]
    public class FamiliarManager : ScriptableManager
    {
        private readonly ReactiveCollection<Familiar> _familiars = new ();
        public IReadOnlyReactiveCollection<Familiar> Familiars => _familiars;

        protected override void OnInitialize()
        {
            _familiars.Clear();
        }

        protected override void OnFixedUpdate()
        {
            for (int i = 0, len = _familiars.Count; i < len; ++i)
            {
                _familiars[i].Refresh();
            }
        }
        
        public void Add(FamiliarData data)
        {
            var player = Context.Player.Value;
            var familiar = Familiar.FromData(data);
            familiar.Initialize(player);
            _familiars.Add(familiar);
        }

        public void Remove(FamiliarData data)
        {
            for (int i = 0; i < _familiars.Count; ++i)
            {
                if (!_familiars[i].Data.Equals(data)) continue;
                _familiars.RemoveAt(i);
                return;
            }
        }
    }
}