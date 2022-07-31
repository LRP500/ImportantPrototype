using System.Collections.Generic;
using System.Linq;
using ImportantPrototype.Gameplay.Mutations;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI.LevelUp
{
    public class LevelUpSwapMutationView : CompositeElement
    {
        [SerializeField]
        private MutationManager _mutationManager;
        
        [SerializeField]
        private MutationReactiveListVariable _selectedMutations;

        [SerializeField]
        private Button _validateButton;
        
        private LevelUpView _levelUp;

        protected override void Awake()
        {
            base.Awake();
            
            _validateButton
                .OnClickAsObservable()
                .DoOnSubscribe(() => _selectedMutations.Values.Clear())
                .Where(_ => _selectedMutations.Values.Count == 2)
                .Select(_ => _selectedMutations.Values.ToList().GetRange(0, 2))
                .Subscribe(OnValidateButtonClicked)
                .AddTo(gameObject);
        }

        private void OnValidateButtonClicked(IReadOnlyList<Mutation> mutations)
        {
            _mutationManager.Swap(mutations[0], mutations[1]);
            _levelUp ??= GetComponentInParent<LevelUpView>();
            _selectedMutations.Values.Clear();
            _levelUp.Hide();
        }
    }
}