using ImportantPrototype.Characters;
using ImportantPrototype.Input;
using ImportantPrototype.Mutations;
using ImportantPrototype.Stats;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.Variables;

namespace ImportantPrototype.Leveling
{
    public class LevelUpManager : MonoBehaviour
    {
        [SerializeField]
        private PlayerReactiveVariable _player;

        [SerializeField]
        private MutationManager _mutationManager;

        [SerializeField]
        private MutationReactiveVariable _selectedMutation;
        
        [SerializeField]
        [InlineEditor(InlineEditorObjectFieldModes.Foldout)]
        private FloatVariable _healAmount;

        [SerializeField]
        [InlineEditor(InlineEditorObjectFieldModes.Foldout)]
        private IntVariable _rerollCount;
        
        [SerializeField]
        [InlineEditor(InlineEditorObjectFieldModes.Foldout)]
        private IntVariable _mutationChoiceCount;

        [SerializeField]
        private ElementReactiveVariable _levelUpScreen;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _player.Value.Stats
                .ObserveAttribute(CharacterStatType.Level)
                .Where(value => value > 0)
                .Subscribe(_ => OnLevelUp())
                .AddTo(gameObject);
        }

        private void OnLevelUp()
        {
            PauseManager.Pause();
            PauseManager.AllowPausing = false;
            PlayerInput.Map = PlayerInput.InputMap.Menu;

            _mutationManager.SetMutationChoices();
            _levelUpScreen.Value.Show();
        }

        public void OnMutationSelected(Mutation mutation)
        {
            _mutationManager.Pick(mutation);
            Resume();
        }
        
        public void OnHealSelected()
        {
            _player.Value.Stats
                .Get<Vital>(CharacterStatType.Health).Current
                .Add(_healAmount);
            Resume();
        }

        public void OnRerollMutationsSelected()
        {
            _mutationManager.SetMutationChoices();
            _levelUpScreen.Value.Refresh();
        }

        public void OnRerollModSelected()
        {
            if (_selectedMutation.Value == null) return;
            _mutationManager.RerollModifier(_selectedMutation.Value);
            Resume();
        }

        public void OnSwapMutationsSelected()
        { }

        private void Resume()
        {
            _levelUpScreen.Value.Hide();
            PlayerInput.Map = PlayerInput.InputMap.Gameplay;
            PauseManager.Resume();
        }
    }
}