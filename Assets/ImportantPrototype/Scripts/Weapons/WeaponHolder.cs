using UniRx;
using UnityEngine;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.Weapons
{
    public class WeaponHolder : MonoBehaviour
    {
        private readonly ReactiveProperty<Weapon> _equippedWeapon = new ();
        public IReadOnlyReactiveProperty<Weapon> EquippedWeapon => _equippedWeapon;

        public void SetRotation(float angle)
        {
            transform.rotation = Quaternion.AngleAxis(angle, -Vector3.forward);
            Flip(!angle.InRange(-90, 90));
        }

        private void Flip(bool flipped)
        {
            _equippedWeapon.Value.Renderer.flipY = flipped;
        }
        
        public void EquipWeapon(WeaponData weaponData)
        {
            UnequipWeapon();
            if (weaponData == null) return;
            var weapon = Weapon.FromData(weaponData);
            weapon.transform.SetParent(transform, false);
            _equippedWeapon.Value = weapon;
        }

        private void UnequipWeapon()
        {
            if (_equippedWeapon.Value == null) return;
            Destroy(_equippedWeapon.Value.gameObject);
            _equippedWeapon.Value = null;
        }
    }
}