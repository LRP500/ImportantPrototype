using UnityEngine;

namespace ImportantPrototype.Input
{
    public static class PlayerInput
    {
        private static float MoveHorizontal => UnityEngine.Input.GetAxisRaw("Horizontal");
        private static float MoveVertical => UnityEngine.Input.GetAxisRaw("Vertical");
        
        public static Vector2 MousePosition => UnityEngine.Input.mousePosition;
        public static Vector2 Move => new (MoveHorizontal, MoveVertical);
        public static bool Fire => UnityEngine.Input.GetKeyDown(KeyCode.Mouse0);
    }
}