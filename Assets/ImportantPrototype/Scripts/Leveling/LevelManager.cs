using ImportantPrototype.Characters;
using ImportantPrototype.Managers;
using ImportantPrototype.Stats;
using ImportantPrototype.System;
using UniRx;
using UnityEngine;

namespace ImportantPrototype.Leveling
{
    [CreateAssetMenu(menuName = ContextMenuPath.Managers + "Level Manager")]
    public class LevelManager : ScriptableManager
    {
        [SerializeField]
        private PlayerReactiveVariable _player;

        [SerializeField]
        private float _xpConstant;

        public ModifiableStat Level { get; private set; }
        public ModifiableStat Experience { get; private set; }

        protected override void OnInitialize()
        {
            Level = _player.Value.Stats.Get(CharacterStatType.Level);
            Experience = _player.Value.Stats.Get(CharacterStatType.Experience);
            
            Experience.Property
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
        
        private float GetRequiredXP(int level)
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
