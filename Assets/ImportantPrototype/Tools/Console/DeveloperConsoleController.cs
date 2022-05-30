using System;
using Extensions;
using TMPro;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

namespace ImportantPrototype.Tools.Console
{
    public class DeveloperConsoleController : UnityTools.Runtime.Singleton<DeveloperConsoleController>
    {
        [SerializeField]
        private DeveloperConsoleSettings _settings;
        
        [SerializeField]
        private Canvas _canvas;

        [SerializeField]
        private TMP_InputField _inputField;

        private bool _isOpened;
        private float _pausedTimeScale;
        private DeveloperConsole _console;
        private readonly SerialDisposable _disposable = new();
        
        protected override void Awake()
        {
            base.Awake();
            Initialize();
        }
        
        private void Initialize()
        {
            _canvas.enabled = false;
            _console ??= new DeveloperConsole(_settings.Prefix, _settings.Commands);
            _inputField.textComponent.fontSize = _settings.FontSize;
        }

        private void OnDestroy()
        {
            _disposable?.Dispose();
        }

        private void Open()
        {
            if (_settings.PauseGame)
            {
                _pausedTimeScale = Time.timeScale;
                Time.timeScale = 0;
            }

            _inputField.enabled = true;
            _inputField.ActivateInputField();
            _disposable.Disposable = _inputField.onEndEdit
                .AsObservable()
                .Subscribe(ProcessCommand);

            _canvas.enabled = true;
            _isOpened = true;
        }

        private void Close()
        {
            Time.timeScale = _pausedTimeScale;
            _canvas.enabled = false;
            _inputField.DeactivateInputField();
            _inputField.enabled = false;
            _isOpened = false;
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
            if (_isOpened) Close();
            else Open();
        }

        private void ProcessCommand(string input)
        {
            _console.ProcessInput(input);
            _inputField.SetTextWithoutNotify(string.Empty);
            _inputField.ActivateInputField();
        }
    }
}