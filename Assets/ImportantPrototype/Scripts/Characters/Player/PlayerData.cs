using ImportantPrototype.System;
using ImportantPrototype.Weapons;
using UnityEngine;

namespace ImportantPrototype.Characters
{
    [CreateAssetMenu(menuName = ContextMenuPath.Characters + "Player Data")]
    public class PlayerData : CharacterData
    {
        [SerializeField]
        private WeaponData _weapon;

        public WeaponData Weapon => _weapon;
    }
}