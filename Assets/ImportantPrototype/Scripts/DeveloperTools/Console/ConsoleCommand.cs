using UnityEngine;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.Tools.Console
{
    public abstract class ConsoleCommand : ScriptableObject, IConsoleCommand
    {
        [SerializeField]
        private string _name;

        public string Name => _name;
        
        public abstract bool Execute(string[] args);

        protected static bool GetBool(string arg, out bool result)
        {
            result = false;
            if (bool.TryParse(arg, out bool boolValue))
            {
                result = boolValue;
                return true;
            }

            if (!int.TryParse(arg, out int intValue)) return false;
            if (!intValue.InRange(0, 1, true)) return false;
            result = intValue == 1;
            return true;
        }
    }
}