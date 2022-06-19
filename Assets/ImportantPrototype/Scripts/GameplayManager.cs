using ImportantPrototype.Characters;
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
        
        [Space]
        [SerializeField]
        private ScriptableEvent _gameOverEvent;

        [SerializeField]
        private ScriptableEvent _levelUpEvent;

        private void Start()
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
                .Where(value => value <= 0)
                .Subscribe(_ => GameOver())
                .AddTo(gameObject);

            _player.Value.Stats
                .ObserveAttribute(CharacterStatType.Level)
                .Where(value => value > 0)
                .Subscribe(_ => OnPlayerLevelUp())
                .AddTo(gameObject);
        }

        private void OnPlayerLevelUp()
        {
            PauseManager.Pause();
            PauseManager.AllowPausing = false;
            _levelUpEvent.Raise();
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