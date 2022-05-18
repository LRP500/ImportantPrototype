using ImportantPrototype.System;
using UnityEngine;
using UnityTools.Runtime.Variables;

namespace ImportantPrototype.Characters
{
    [CreateAssetMenu(menuName = ContextMenuPath.Characters + "Player Reactive Variable")]
    public class PlayerReactiveVariable : ReactiveVariable<Player>
    { }
}