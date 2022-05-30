using UnityEngine;

namespace ImportantPrototype.Tools.Console
{
    public abstract class ConsoleCommand : ScriptableObject, IConsoleCommand
    {
        [SerializeField]
        private string _name;

        public string Name => _name;
        public abstract bool Execute(string[] args);
    }
}