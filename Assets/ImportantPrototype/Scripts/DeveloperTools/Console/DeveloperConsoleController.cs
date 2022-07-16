using TMPro;
using UniRx;
using UnityEngine;
using UnityTools.Runtime;

namespace ImportantPrototype.Tools.Console
{
    public class DeveloperConsoleController : Singleton<DeveloperConsoleController>
    {
        [SerializeField]
        private DeveloperConsoleSettings _settings;
        
        [SerializeField]
        private Canvas _canvas;

        [SerializeField]
        private TMP_InputField _inputField;

        private DeveloperConsole _console;
        private readonly BoolReactiveProperty _isOpen = new (false);
        private readonly SerialDisposable _disposable = new();

        public IReadOnlyReactiveProperty<bool> IsOpen => _isOpen;

        protected override void Awake()
        {
            base.Awake();
            Initialize();
        }
        
        private void Initialize()
        {
            _canvas.enabled = false;
            _inputField.textComponent.fontSize = _settings.FontSize;
            _console ??= new DeveloperConsole(_settings.Prefix, _settings.Commands);
        }

        private void OnDestroy()
        {
            _disposable?.Dispose();
        }

        private void Open()
        {
            _inputField.enabled = true;
            _inputField.ActivateInputField();
            _disposable.Disposable = _inputField.onEndEdit
                .AsObservable()
                .Subscribe(ProcessCommand);

            _canvas.enabled = true;
            _isOpen.Value = true;
        }

        private void Close()
        {
            _canvas.enabled = false;
            _inputField.DeactivateInputField();
            _inputField.enabled = false;
            _isOpen.Value = false;
        }
        
        private void OnDisable()
        {
            Close();
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.BackQuote))
            {
                Toggle();
            }
        }

        private void Toggle()
        {
            if (_isOpen.Value) Close();
            else Open();
        }

        public void ProcessCommand(string input)
        {
            _console.ProcessInput(input);
            _inputField.SetTextWithoutNotify(string.Empty);
            _inputField.ActivateInputField();
        }
    }
}