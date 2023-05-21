using UnityEngine;

namespace ET
{
    [ComponentOf(typeof (Unit))]
    public class PlayerControllerComponent: Entity, IAwake, IUpdate
    {
        public PlayerInputControl InputControl;
        public Vector2 inputDirection;
        public Rigidbody2D Rigidbody2D;
        public float speed = 200.0f;
    }
}