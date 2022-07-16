using ImportantPrototype.Characters;
using ImportantPrototype.Leveling;
using ImportantPrototype.System;
using UnityEngine;
using UnityEngine.Serialization;
using Attribute = ImportantPrototype.Stats.Attribute;

namespace ImportantPrototype.Tools.Console.Commands
{
    [CreateAssetMenu(menuName = ContextMenuPath.ConsoleCommands + "Level Up")]
    public class LevelUpCommand : ConsoleCommand
    {
        [FormerlySerializedAs("_levelManager")]
        [SerializeField]
        private PlayerLevelManager _playerLevelManager;

        [SerializeField]
        private PlayerReactiveVariable _player;
        
        public override bool Execute(string[] args)
        {
            var level = _player.Value.Stats
                .Get<Attribute>(CharacterStatType.Level);
            var requiredXp = _playerLevelManager
                .GetRequiredXP((int) level.Value + 1);
            _player.Value.Stats
                .Get<Attribute>(CharacterStatType.Experience)
                .SetValue(requiredXp);
            return true;
        }
    }
}
