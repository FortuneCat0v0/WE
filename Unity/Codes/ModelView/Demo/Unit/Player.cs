using UnityEngine;

namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class Player: Entity, IAwake, IUpdate, IDestroy
    {
        public Rigidbody2D Rigidbody2D;
        public float speed;
        public Vector2 movementInput;
        public PlayerInputControl InputControl;
    }
}