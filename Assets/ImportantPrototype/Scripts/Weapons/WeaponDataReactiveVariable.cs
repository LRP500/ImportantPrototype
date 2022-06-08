using ImportantPrototype.System;
using UnityEngine;
using UnityTools.Runtime.Variables;

namespace ImportantPrototype.Weapons
{
    [CreateAssetMenu(menuName = ContextMenuPath.Weapons + "Weapon Data Reactive Variable")]
    public class WeaponDataReactiveVariable : ReactiveVariable<WeaponData>
    { }
}