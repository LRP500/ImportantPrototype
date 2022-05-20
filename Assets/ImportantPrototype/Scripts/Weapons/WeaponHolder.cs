using UnityEngine;

namespace ImportantPrototype.Weapons
{
    public class WeaponHolder : MonoBehaviour
    {
        public void SetRotation(float angle)
        {
            transform.rotation = Quaternion.AngleAxis(angle, -Vector3.forward);
        }
    }
}