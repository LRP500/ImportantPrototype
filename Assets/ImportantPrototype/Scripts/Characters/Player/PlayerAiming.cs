using ImportantPrototype.Input;
using ImportantPrototype.Weapons;
using UnityEngine;
using UnityTools.Runtime.Variables;

namespace ImportantPrototype.Characters
{
    [RequireComponent(typeof(Player))]
    public class PlayerAiming : MonoBehaviour
    {
        [SerializeField]
        private CameraVariable _cameraVariable;

        private Player _player;

        public Vector2 AimDirection { get; private set; }
        public float AimAngle { get; private set; }

        private void Awake()
        {
            _player = GetComponent<Player>();
        }

        private void Update()
        {
            if (Time.timeScale == 0) return;
            UpdateAim();
        }

        private void UpdateAim()
        {
            Vector3 origin = _player.Position;
            var target =  _cameraVariable.Value.ScreenToWorldPoint(PlayerInput.MousePosition);
            var aimDir = (target - origin).normalized;

            AimDirection = aimDir;
            AimAngle = Mathf.Atan2(aimDir.x, aimDir.y) * Mathf.Rad2Deg - 90;
            
            _player.WeaponHolder.SetRotation(AimAngle);
        }
    }
}