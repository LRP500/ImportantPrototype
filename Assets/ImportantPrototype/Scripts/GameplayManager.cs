using ImportantPrototype.Characters;
using ImportantPrototype.Level;
using ImportantPrototype.Weapons;
using UniRx;
using UnityEngine;
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
        private WeaponDataReactiveVariable _selectedWeapon;
        
        [SerializeField]
        private LevelManager _levelManager;
        
        [SerializeField]
        private ScriptableEvent _gameOverEvent;

        private void Start()
        {
            SetupGame();       
            _levelManager.StartLevel();
        }

        private void SetupGame()
        {
            _context.Initialize();
            SetupPlayer();
        }
        
        private void SetupPlayer()
        {
            _player.Value.WeaponHolder
                .EquipWeapon(_selectedWeapon.Value);

            _player.Value.Stats
                .ObserveVital(CharacterStatType.Health)
                .Skip(1)
                .Where(value => value <= 0)
                .Subscribe(_ => GameOver())
                .AddTo(gameObject);
        }

        private void FixedUpdate()
        {
            _context.FixedUpdate();
        }

        private void GameOver()
        {
            PauseManager.AllowPausing = false;
            _gameOverEvent.Raise();
            _player.Value.Freeze();
        }
    }
}