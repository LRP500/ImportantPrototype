using UniRx;
using UnityEngine;

namespace ImportantPrototype.Tools.Console
{
    [RequireComponent(typeof(DeveloperConsoleController))]
    public class DeveloperConsoleInputController : MonoBehaviour
    {
        [SerializeField]
        private DeveloperConsoleInputSettings _settings;
        
        private DeveloperConsoleController _consoleController;
        
        private void Awake()
        {
            _consoleController = GetComponent<DeveloperConsoleController>();
            _consoleController.IsOpen
                .SkipLatestValueOnSubscribe()
                .Distinct()
                .Subscribe(isOpen => SetEnabled(!isOpen))
                .AddTo(gameObject);
        }

        private void SetEnabled(bool value)
        {
            enabled = value;
        }

        private void Update()
        {
            if (!UnityEngine.Input.anyKeyDown) return;
            
            foreach (var (command, keycode) in _settings.Keybindings)
            {
                if (UnityEngine.Input.GetKeyDown(keycode))
                {
                    _consoleController.ProcessCommand(command.Name);
                }
            }
        }
    }
}