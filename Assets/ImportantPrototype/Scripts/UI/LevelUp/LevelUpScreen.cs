using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityTools.Runtime.ECA.Events;
using UnityTools.Runtime.UI;

namespace ImportantPrototype.UI
{
    public class LevelUpScreen : Element
    {
        [SerializeField]
        private ScriptableEvent _mutationSelectedEvent;
        
        public override void Initialize()
        {
            this.UpdateAsObservable()
                .Where(_ => UnityEngine.Input.GetKeyDown(KeyCode.Space))
                .Subscribe(_ => OnMutationSelected())
                .AddTo(gameObject);
        }

        private void OnMutationSelected()
        {
            _mutationSelectedEvent.Raise();
            PauseManager.Resume();
            Hide();
        }
    }
}