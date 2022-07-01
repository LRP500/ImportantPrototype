using ImportantPrototype.Characters;
using ImportantPrototype.Managers;
using ImportantPrototype.Stats;
using ImportantPrototype.System;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.Leveling
{
    [CreateAssetMenu(menuName = ContextMenuPath.Managers + "Player Level Manager")]
    public class PlayerLevelManager : ScriptableManager
    {
        [SerializeField]
        private float _xpConstant;

        public Attribute Level { get; private set; }
        public Attribute Experience { get; private set; }

        protected override void OnInitialize()
        {
            var stats = Context.Player.Value.Stats; 
            Level = stats.Get<Attribute>(CharacterStatType.Level);
            Experience = stats.Get<Attribute>(CharacterStatType.Experience);

            Experience.Property
                .SkipFirst()
                .Subscribe(OnPlayerGainedXP)
                .AddTo(Context.DisposableTarget);
        }

        private void OnPlayerGainedXP(float currentXp)
        {
            int level = GetLevelFromXp(currentXp);
            if (level != Mathf.FloorToInt(Level.Value))
            {
                Level.SetValue(level);
            }
        }

        private int GetLevelFromXp(float xp)
        {
            return Mathf.FloorToInt(_xpConstant * Mathf.Sqrt(xp));
        }
        
        public float GetRequiredXP(int level)
        {
            return level * level / (_xpConstant * _xpConstant);
        }

        public float GetCurrentLevelRatio()
        {
            var level = GetLevelFromXp(Experience.Value);
            var levelXP = GetRequiredXP(level + 1) - GetRequiredXP(level);
            var currentLevelXp = Experience.Value - GetRequiredXP(level);
            return currentLevelXp / levelXP;
        }
    }
}
