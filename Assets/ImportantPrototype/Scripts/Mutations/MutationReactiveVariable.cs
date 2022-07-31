using ImportantPrototype.System;
using UnityEngine;
using UnityTools.Runtime.Variables;

namespace ImportantPrototype.Gameplay.Mutations
{
    [CreateAssetMenu(menuName = ContextMenuPath.Mutations + "Mutation Reactive Variable")]
    public class MutationReactiveVariable : ReactiveVariable<Mutation>
    { }
}