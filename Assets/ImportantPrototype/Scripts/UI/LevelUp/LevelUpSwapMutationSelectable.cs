using ImportantPrototype.Mutations;
using ImportantPrototype.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ImportantPrototype.Scripts.UI.LevelUp
{
    public class LevelUpSwapMutationSelectable : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private MutationReactiveListVariable _selectedMutations;

        private MutationView _view;

        private void Awake()
        {
            _view = GetComponent<MutationView>();
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            _selectedMutations.Values.Add(_view.Mutation);

            if (_selectedMutations.Values.Count >= 2)
            {
                _selectedMutations.Values.RemoveAt(0);
            }
        }
    }
}