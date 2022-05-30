using ImportantPrototype.System;
using UnityEngine;

namespace ImportantPrototype.Tools.Console.Commands
{
    [CreateAssetMenu(menuName = ContextMenuPath.ConsoleCommands + "Log")]
    public class LogCommand : ConsoleCommand
    {
        public override bool Execute(string[] args)
        {
            if (args.Length == 0) return false;
            string logMessage = string.Join(" ", args);
            Debug.Log(logMessage);
            return true;
        }
    }
}