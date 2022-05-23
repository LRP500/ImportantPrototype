using UnityEngine;

namespace ImportantPrototype.Characters
{
    [RequireComponent(typeof(PlayerAiming))]
    [RequireComponent(typeof(PlayerShooting))]
    public class Player : Character
    {
        public PlayerAiming Aiming { get; private set; }
        public PlayerShooting Shooting { get; private set; }
        
        protected override void OnInitialize()
        {
            Aiming = GetComponent<PlayerAiming>();
            Shooting = GetComponent<PlayerShooting>();
        }

        public void Freeze()
        {
            Motor.enabled = false;
            Aiming.enabled = false;
            Shooting.enabled = false;
        }
    }
}