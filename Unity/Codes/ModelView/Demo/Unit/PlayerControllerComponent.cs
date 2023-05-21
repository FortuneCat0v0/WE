using UnityEngine;

namespace ET
{
    [ComponentOf(typeof (Unit))]
    public class PlayerControllerComponent: Entity, IAwake, IUpdate
    {
        public PlayerInputControl InputControl;
        public Vector2 inputDirection;
        public Rigidbody2D Rigidbody2D;
        public SpriteRenderer SpriteRenderer;
        public Transform Transform;
        public bool faceDir;
        public float speed = 5f;
        public float jumpForce = 20f;
    }
}