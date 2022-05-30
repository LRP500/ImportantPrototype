using System.Collections.Generic;
using ImportantPrototype.System;
using UnityEngine;

namespace ImportantPrototype.Tools.Console
{
    [CreateAssetMenu(menuName = ContextMenuPath.Console + "Developer Console Settings")]
    public class DeveloperConsoleSettings : ScriptableObject
    {
        [SerializeField]
        private string _prefix;

        [SerializeField]
        private bool _pauseGame = true;

        [SerializeField]
        private float _fontSize = 24;
        
        [SerializeField]
        private ConsoleCommand[] _commands;

        public string Prefix => _prefix;
        public bool PauseGame => _pauseGame;
        public float FontSize => _fontSize;
        public IReadOnlyList<ConsoleCommand> Commands => _commands;
    }
}
