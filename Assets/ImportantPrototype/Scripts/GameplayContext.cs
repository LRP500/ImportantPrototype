using ImportantPrototype.System;
using UnityEngine;
using UnityTools.Runtime.Variables;

namespace ImportantPrototype.Scripts
{
    [CreateAssetMenu(menuName = ContextMenuPath.Root + "Gameplay Context")]
    public class GameplayContext : ScriptableObject
    {
        [SerializeField]
        private GameObjectVariable _disposableTarget;

        public GameObject DisposableTarget => _disposableTarget.Value;
    }
}