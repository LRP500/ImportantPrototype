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
            var selected = _selectedMutations.Values;
            
            if (selected.Contains(_view.Mutation)) return;
            
            selected.Add(_view.Mutation);

            if (selected.Count > 2)
            {
                selected.RemoveAt(0);
            }
        }
    }
}