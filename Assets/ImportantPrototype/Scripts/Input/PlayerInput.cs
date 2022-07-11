using System;
using UniRx;
using UnityEngine;

namespace ImportantPrototype.Input
{
    public static class PlayerInput
    {
        public enum InputMap
        {
            Gameplay = 0,
            Menu = 1
        }

        public static InputMap Map { get; set; } = InputMap.Gameplay; 
        
        private static float MoveHorizontal => UnityEngine.Input.GetAxisRaw("Horizontal");
        private static float MoveVertical => UnityEngine.Input.GetAxisRaw("Vertical");
        
        public static Vector2 MousePosition => UnityEngine.Input.mousePosition;
        public static Vector2 Move => new (MoveHorizontal, MoveVertical);

        public static bool Back => UnityEngine.Input.GetKeyDown(KeyCode.Escape);
        
        public static IObservable<bool> ObserveFiring()
        {
            return Observable.EveryUpdate()
                .Select(_ => UnityEngine.Input.GetKey(KeyCode.Mouse0));
        }

        public static IObservable<Unit> ObservePause()
        {
            return Observable
                .EveryUpdate()
                .Where(_ => UnityEngine.Input.GetKeyDown(KeyCode.Escape))
                .AsUnitObservable();
        }

        public static IObservable<Unit> ObserveTab()
        {
            return Observable
                .EveryUpdate()
                .Where(_ => UnityEngine.Input.GetKeyDown(KeyCode.Tab))
                .Where(_ => Map == InputMap.Gameplay)
                .AsUnitObservable();
        }
    }
}