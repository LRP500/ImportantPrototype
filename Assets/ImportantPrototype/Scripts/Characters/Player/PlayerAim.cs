using ImportantPrototype.Input;
using ImportantPrototype.Weapons;
using UnityEngine;
using UnityTools.Runtime.Variables;

namespace ImportantPrototype.Characters
{
    [RequireComponent(typeof(Player))]
    public class PlayerAim : MonoBehaviour
    {
        [SerializeField]
        private CameraVariable _cameraVariable;

        [SerializeField]
        private WeaponHolder _weaponHolder;

        private Player _player;

        private void Awake()
        {
            _player = GetComponent<Player>();
        }

        private void Update()
        {
            Vector3 origin = _player.Position;
            var target =  _cameraVariable.Value.ScreenToWorldPoint(PlayerInput.MousePosition);
            var aimDir = (target - origin).normalized;
            var aimAngle = Mathf.Atan2(aimDir.x, aimDir.y) * Mathf.Rad2Deg;
            _weaponHolder.SetRotation(aimAngle - 90);
        }
    }
}
