using ImportantPrototype.Characters;
using ImportantPrototype.System;
using UnityEngine;

namespace ImportantPrototype.Tools.Console.Commands
{
    [CreateAssetMenu(menuName = ContextMenuPath.ConsoleCommands + "God Mode")]
    public class GodModeCommand : ConsoleCommand
    {
        [SerializeField]
        private PlayerReactiveVariable _player;
        
        public override bool Execute(string[] args)
        {
            if (args.Length != 1) return false;
            if (!GetBool(args[0], out bool enabled)) return false;
            _player.Value.Damageable.SetCanDamage(!enabled);
            return true;
        }
    }
}