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

        public SpriteRenderer Renderer => _renderer;

        private Character Holder { get; set; }
        public WeaponData Data { get; private set; }
        public WeaponStatCollection Stats { get; private set; }

        public float FireRate => Stats.Get<Attribute>(WeaponStatType.FireRate).Value;
        public float Damage => Stats.Get<Attribute>(WeaponStatType.Damage).Value;
        
        public static Weapon FromData(WeaponData data)
        {
            var instance = Instantiate(data.Prefab);
            instance.Stats = WeaponStatCollection.FromWeaponData(data);
            instance.Data = data;
            return instance;
        }

        public void Bind(Character holder)
        {
            Holder = holder;
        }
        
        public void Fire(Vector2 direction, string excludeTag)
        {
            Data.ShotBehaviour.Fire(this, _muzzle.position, direction, excludeTag);
        }
    }
}