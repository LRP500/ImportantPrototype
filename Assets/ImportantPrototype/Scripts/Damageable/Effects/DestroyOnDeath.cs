﻿using ImportantPrototype.Gameplay;
using UnityEngine;

namespace ImportantPrototype.Scripts.Damageable.Effects
{
    public class DestroyOnDeath : DeathEffect
    {
        [SerializeField]
        private GameObject _root;
        
        protected override void Trigger()
        {
            Destroy(_root);
        }
    }
}