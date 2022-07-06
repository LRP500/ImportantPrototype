using ImportantPrototype.Characters;
using ImportantPrototype.Stats;
using UnityEngine;

namespace ImportantPrototype.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _renderer;
        
        [SerializeField]
        private Transform _muzzle;

        private WeaponShotBehaviour _behaviour;
        
        public SpriteRenderer Renderer => _renderer;

        public Character Holder { get; private set; }
        public WeaponData Data { get; private set; }
        public WeaponStatCollection Stats { get; private set; }
        
        public static Weapon FromData(WeaponData data)
        {
            var instance = Instantiate(data.Prefab);
            instance.Initialize(data);
            return instance;
        }

        private void Initialize(WeaponData data)
        {
            Data = data;
            Stats = WeaponStatCollection.FromWeaponData(data);
            _behaviour = Instantiate(data.ShotBehaviour);
        }
        
        public void Bind(Character holder)
        {
            Holder = holder;
        }
        
        public void Fire(Vector2 direction, string excludeTag)
        {
            _behaviour.Fire(this, _muzzle.position, direction, excludeTag);
        }
    }
}