using ImportantPrototype.Characters;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.Weapons
{
    public class WeaponHolder : MonoBehaviour
    {
        private readonly ReactiveProperty<Weapon> _weapon = new ();
        public IReadOnlyReactiveProperty<Weapon> Weapon => _weapon;

        private Character _holder;
        
        private void Awake()
        {
            _holder = GetComponentInParent<Character>();
        }

        public void Initialize()
        {
            if (_weapon.Value == null)
            {
                EquipWeapon(_holder.Data.Weapon);
            }            
        }
        
        public void SetRotation(float angle)
        {
            transform.rotation = Quaternion.AngleAxis(angle, -Vector3.forward);
            Flip(!angle.InRange(-90, 90));
        }

        private void Flip(bool flipped)
        {
            _weapon.Value.Renderer.flipY = flipped;
        }
        
        public void EquipWeapon(WeaponData weaponData)
        {
            if (weaponData == null) return;
            UnequipWeapon();
            var weapon = Weapons.Weapon.FromData(weaponData);
            weapon.transform.SetParent(transform, false);
            weapon.Attach(_holder);
            _weapon.Value = weapon;
        }

        private void UnequipWeapon()
        {
            if (_weapon.Value == null) return;
            Destroy(_weapon.Value.gameObject);
            _weapon.Value = null;
        }
    }
}