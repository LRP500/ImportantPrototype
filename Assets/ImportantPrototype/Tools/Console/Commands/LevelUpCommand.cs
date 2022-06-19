using ImportantPrototype.Characters;
using ImportantPrototype.Leveling;
using ImportantPrototype.System;
using UnityEngine;
using Attribute = ImportantPrototype.Stats.Attribute;

namespace ImportantPrototype.Tools.Console.Commands
{
    [CreateAssetMenu(menuName = ContextMenuPath.ConsoleCommands + "Level Up")]
    public class LevelUpCommand : ConsoleCommand
    {
        [SerializeField]
        private LevelManager _levelManager;

        [SerializeField]
        private PlayerReactiveVariable _player;
        
        public override bool Execute(string[] args)
        {
            var level = _player.Value.Stats
                .Get<Attribute>(CharacterStatType.Level);
            var requiredXp = _levelManager
                .GetRequiredXP((int) level.Value + 1);
            _player.Value.Stats
                .Get<Attribute>(CharacterStatType.Experience)
                .SetValue(requiredXp);
            return true;
        }
    }
}
