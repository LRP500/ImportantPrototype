using System.Collections.Generic;
using ImportantPrototype.System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace ImportantPrototype.Tools.Console
{
    [CreateAssetMenu(menuName = ContextMenuPath.Console + "Developer Console Input Settings")]
    public class DeveloperConsoleInputSettings : SerializedScriptableObject
    {
        [OdinSerialize]
        private Dictionary<ConsoleCommand, KeyCode> _keybindings;

        public Dictionary<ConsoleCommand, KeyCode> Keybindings => _keybindings;
    }
}