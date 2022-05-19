using UnityEngine;

namespace ImportantPrototype.Weapons
{
    public class WeaponHolder : MonoBehaviour
    {
        public void SetRotation(float angle)
        {
            // transform.eulerAngles = new Vector3(0, 0, angle);
            transform.rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
        }
    }
}
