using UnityEngine;

namespace ImportantPrototype.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _renderer;
        
        [SerializeField]
        private Transform _muzzle;

        public SpriteRenderer Renderer => _renderer;
        public WeaponData Data { get; private set; }

        public static Weapon FromData(WeaponData data)
        {
            var instance = Instantiate(data.Prefab);
            instance.Data = data;
            return instance;
        }

        public void Fire(Vector2 direction, string excludeTag)
        {
            Data.ShotBehaviour.Fire(Data, _muzzle.position, direction, excludeTag);
        }
    }
}