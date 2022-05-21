using UnityEngine;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.Weapons
{
    public class WeaponHolder : MonoBehaviour
    {
        [SerializeField]
        private Weapon _weapon;

        public Weapon Weapon => _weapon;
        
        public void SetRotation(float angle)
        {
            transform.rotation = Quaternion.AngleAxis(angle, -Vector3.forward);
            Flip(!angle.InRange(-90, 90));
        }

        private void Flip(bool flipped)
        {
            Weapon.Renderer.flipY = flipped;
        }
    }
}