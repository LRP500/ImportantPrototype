using UnityEngine;

namespace ImportantPrototype.Scripts
{
    public class GameplayManager : MonoBehaviour
    {
        [SerializeField]
        private GameplayContext _context;

        public void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _context.Initialize();
        }

        private void FixedUpdate()
        {
            _context.FixedUpdate();
        }
    }
}