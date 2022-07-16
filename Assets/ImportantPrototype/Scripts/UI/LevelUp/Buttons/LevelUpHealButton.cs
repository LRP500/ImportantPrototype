using System;
using ImportantPrototype.Characters;
using ImportantPrototype.Stats;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.Extensions;
using UnityTools.Runtime.Variables;

namespace ImportantPrototype.UI
{
    public class LevelUpHealButton : ConditionalButton
    {
        [SerializeField]
        private PlayerReactiveVariable _player;

        [SerializeField]
        private BoolVariable _allowHealOverflow;
        
        protected override void SetInteractable(bool interactable)
        {
            gameObject.SetActive(interactable);
        }
        
        protected override IObservable<bool> ObserveCanInteract()
        {
            if (_allowHealOverflow)
            {
                return Observable.Return(true);
            }
            
            return _player.Property
                .WhereNotNull()
                .CombineLatest(_player.Value.Stats
                        .Get<Vital>(CharacterStatType.Health)
                        .ObserveFull(),
                (_, fullHealth) => !fullHealth || _allowHealOverflow);
        }
    }
}