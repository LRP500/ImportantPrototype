using ImportantPrototype.System;
using UnityEngine;

namespace ImportantPrototype.Level
{
    [CreateAssetMenu(menuName = ContextMenuPath.Root + "Level Data")]
    public class LevelData : ScriptableObject
    {
        [SerializeField]
        private string _name;

        [Multiline]
        [SerializeField]
        private string _description;

        [SerializeField]
        private string _sceneName;

        public string SceneName => _sceneName;
    }
}