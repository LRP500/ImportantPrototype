using UniRx;
using UnityEngine;
using Attribute = ImportantPrototype.Stats.Attribute;

namespace ImportantPrototype.Characters
{
    public class CharacterSize : MonoBehaviour
    {
        [SerializeField]
        private CharacterStats _stats;
        
        private void Start()
        {
            _stats.Get<Attribute>(CharacterStatType.CharacterSize).Property
                .Subscribe(SetSize)
                .AddTo(gameObject);
        }

        private void SetSize(float size)
        {
            transform.localScale = new Vector3(size, size, size);
        }
    }
}