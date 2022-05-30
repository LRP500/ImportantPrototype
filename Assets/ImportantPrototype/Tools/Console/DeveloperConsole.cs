using System;
using System.Collections.Generic;
using System.Linq;

namespace ImportantPrototype.Tools.Console
{
    public class DeveloperConsole
    {
        private readonly string _prefix;
        private readonly IReadOnlyList<IConsoleCommand> _commands;

        public DeveloperConsole(string prefix, IReadOnlyList<ConsoleCommand> commands)
        {
            _prefix = prefix;
            _commands = commands;
        }

        public void ProcessInput(string input)
        {
            if (!input.StartsWith(_prefix)) return;
            input = input.Remove(0, _prefix.Length);
            
            string[] inputParsed = input.Split(' ');
            string commandName = inputParsed[0];
            string[] args = inputParsed.Skip(1).ToArray();
            
            ProcessCommand(commandName, args);
        }

        private void ProcessCommand(string cmdInput, string[] args)
        {
            for (int i = 0, len = _commands.Count; i < len; ++i)
            {
                var cmd = _commands[i];
                if (!cmdInput.Equals(cmd.Name, StringComparison.OrdinalIgnoreCase)) continue;
                cmd.Execute(args);
                return;
            }
        }
    }
}
