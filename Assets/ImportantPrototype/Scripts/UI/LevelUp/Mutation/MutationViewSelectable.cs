using ImportantPrototype.Mutations;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ImportantPrototype.UI
{
    [RequireComponent(typeof(MutationView))]
    public class MutationViewSelectable : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private MutationReactiveVariable _selectedMutation;

        private MutationView _view;
        private bool _interactable;

        private void Awake()
        {
            _view = GetComponent<MutationView>();
        }

        private void OnEnable()
        {
            _interactable = true;
        }

        private void OnDisable()
        {
            _interactable = false;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            if (!_interactable) return;
            _selectedMutation.SetValue(_view.Mutation);
        }
    }
}