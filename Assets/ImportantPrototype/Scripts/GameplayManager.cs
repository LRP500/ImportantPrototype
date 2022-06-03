using ImportantPrototype.Characters;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityTools.Runtime.ECA.Events;

namespace ImportantPrototype
{
    public class GameplayManager : MonoBehaviour
    {
        [SerializeField]
        private GameplayContext _context;

        [SerializeField]
        private PlayerReactiveVariable _player;

        [SerializeField]
        private ScriptableEvent _gameOverEvent;
        
        public void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _context.Initialize();
            
            _player.Value.Stats
                .ObserveVital(CharacterStatType.Health)
                .Where(value => value <= 0)
                .Subscribe(_ => GameOver());
        }

        public void Restart()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        
        private void FixedUpdate()
        {
            _context.FixedUpdate();
        }

        private void GameOver()
        {
            _player.Value.Freeze();
            _gameOverEvent.Raise();
        }
    }
}