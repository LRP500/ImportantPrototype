using ImportantPrototype.Mutations;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ImportantPrototype.UI
{
    [RequireComponent(typeof(MutationView))]
    public class MutationViewHoverable : MonoBehaviour, IPointerEnterHandler
    {
        [SerializeField]
        private MutationReactiveVariable _hoveredMutation;

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

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!_interactable) return;
            _hoveredMutation.SetValue(_view.Mutation);
        }
    }
}