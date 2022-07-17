using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityTools.Runtime.Extensions;

namespace ImportantPrototype.UI
{
    [RequireComponent(typeof(Button))]
    public abstract class ConditionalButton : MonoBehaviour
    {
        private Button _button;

        protected virtual void Awake()
        {
            _button = GetComponent<Button>();
        }

        protected virtual void Start()
        {
            ObserveCanInteract()
                .DistinctUntilChanged()
                .Subscribe(SetInteractable)
                .AddTo(gameObject);
        }

        protected virtual void SetInteractable(bool interactable)
        {
            _button.interactable = interactable;
        }

        protected virtual IObservable<bool> ObserveCanInteract()
        {
            return Observable.Return(true);   
        }
    }
}