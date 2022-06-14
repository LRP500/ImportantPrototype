using ImportantPrototype.System;
using UnityEngine;
using UnityTools.Runtime.Lists;

namespace ImportantPrototype.Characters.Enemies
{
    [CreateAssetMenu(menuName = ContextMenuPath.Characters + "Enemy Reactive List")]
    public class EnemyReactiveListVariable : ReactiveListVariable<Enemy>
    { }
}