using ImportantPrototype.Characters.Enemies;
using ImportantPrototype.Interfaces;
using ImportantPrototype.System;
using UnityEngine;

namespace ImportantPrototype.Tools.Console.Commands
{
    [CreateAssetMenu(menuName = ContextMenuPath.ConsoleCommands + "Kill All")]
    public class KillAllCommand : ConsoleCommand
    {
        private class Damager : IDamager
        {
            public float Damage => float.MaxValue;
        }
        
        [SerializeField]
        private EnemyReactiveListVariable _enemies;
        
        public override bool Execute(string[] args)
        {
            if (args.Length > 0) return false;

            var damager = new Damager();
            foreach (var enemy in _enemies.Values)
            {
                enemy.Damageable.Damage(damager);
            }
            
            return true;
        }
    }
}