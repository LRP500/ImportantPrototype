using UnityEngine;

namespace ImportantPrototype.Input
{
    public static class PlayerInput
    {
        public static Vector2 MousePosition => UnityEngine.Input.mousePosition;
        private static float MoveHorizontal => UnityEngine.Input.GetAxisRaw("Horizontal");
        private static float MoveVertical => UnityEngine.Input.GetAxisRaw("Vertical");
        public static Vector2 Move => new (MoveHorizontal, MoveVertical);
    }
}