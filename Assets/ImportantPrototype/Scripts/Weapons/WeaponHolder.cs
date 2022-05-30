using UnityEngine;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.Weapons
{
    public class WeaponHolder : MonoBehaviour
    {
        public Weapon EquippedWeapon { get; private set; }

        public void SetRotation(float angle)
        {
            transform.rotation = Quaternion.AngleAxis(angle, -Vector3.forward);
            Flip(!angle.InRange(-90, 90));
        }

        private void Flip(bool flipped)
        {
            EquippedWeapon.Renderer.flipY = flipped;
        }
        
        public void EquipWeapon(WeaponData weaponData)
        {
            UnequipWeapon();
            if (weaponData == null) return;
            var weapon = Weapon.FromData(weaponData);
            weapon.transform.SetParent(transform, false);
            EquippedWeapon = weapon;
        }

        private void UnequipWeapon()
        {
            if (EquippedWeapon == null) return;
            Destroy(EquippedWeapon.gameObject);
            EquippedWeapon = null;
        }
    }
}