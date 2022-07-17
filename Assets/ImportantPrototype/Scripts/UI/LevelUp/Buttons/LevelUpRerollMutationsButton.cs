using System;
using TMPro;
using UniRx;
using UniRx.Diagnostics;
using UnityEngine;
using UnityTools.Runtime.Extensions;
using UnityTools.Runtime.Variables;

namespace ImportantPrototype.UI
{
    public class LevelUpRerollMutationsButton : ConditionalButton
    {
        [SerializeField]
        private IntReactiveVariable _mutationRerollCount;

        [SerializeField]
        private TextMeshProUGUI _name;

        private string _buttonName;

        protected void OnEnable()
        {
            _mutationRerollCount.Property
                .SkipLatestValueOnSubscribe()
                .Subscribe(_ => RefreshText())
                .AddToDisable(this);
        }

        private void RefreshText()
        {
            _buttonName ??= _name.text;
            _name.SetText($"{_buttonName} ({_mutationRerollCount.Value.ToString()})");
        }
        
        protected override void SetInteractable(bool interactable)
        {
            gameObject.SetActive(interactable);
        }

        protected override IObservable<bool> ObserveCanInteract()
        {
            return _mutationRerollCount.Property.Select(x => x > 0);
        }
    }
}