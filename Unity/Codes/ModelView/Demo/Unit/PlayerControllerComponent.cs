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
        public float speed;
        public float jumpForce;

        public Transform FootTransform;
        public float checkRaduis;
        public LayerMask groundLayer;
        public bool isGround;

        public AnimatorComponent AnimatorComponent;
        
        // 同步相关
        public float lastInputDirectionX;
    }
}