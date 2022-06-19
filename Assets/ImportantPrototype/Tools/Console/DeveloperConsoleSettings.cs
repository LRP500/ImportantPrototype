using System.Collections.Generic;
using ImportantPrototype.System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ImportantPrototype.Tools.Console
{
    [CreateAssetMenu(menuName = ContextMenuPath.Console + "Developer Console Settings")]
    public class DeveloperConsoleSettings : ScriptableObject
    {
        [SerializeField]
        private string _prefix;

        [SerializeField]
        private float _fontSize = 24;
        
        [SerializeField]
        [AssetList(AutoPopulate = true)]
        private ConsoleCommand[] _commands;

        public string Prefix => _prefix;
        public float FontSize => _fontSize;
        public IReadOnlyList<ConsoleCommand> Commands => _commands;
    }
}
