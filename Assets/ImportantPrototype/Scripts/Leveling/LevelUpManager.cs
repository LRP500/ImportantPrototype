using ImportantPrototype.Characters;
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

        [SerializeField]
        private MutationReactiveListVariable _mutationChoices;

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

            SetMutationChoices();
            _levelUpScreen.Value.Show();
        }

        public void OnHealSelected()
        {
            _player.Value.Stats
                .Get<Vital>(CharacterStatType.Health).Current
                .Add(_healAmount);
            OnActionTaken();
        }

        public void OnRerollMutationsSelected()
        {
            SetMutationChoices();
            _levelUpScreen.Value.Show();
        }

        private void SetMutationChoices()
        {
            var choices = _mutationManager.GetNextMutationChoices();
            _mutationChoices.SetValues(choices);
        }

        public void OnRerollModSelected()
        {
        }

        public void OnSwapMutationsSelected()
        {
        }

        private void OnActionTaken()
        {
            _levelUpScreen.Value.Hide();
            PauseManager.Resume();
        }
    }
}