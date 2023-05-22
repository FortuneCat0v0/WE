using UnityEngine;
using UnityEngine.InputSystem;

namespace ET
{
    public class PlayerControllerComponentAwakeSystem: AwakeSystem<PlayerControllerComponent>
    {
        public override void Awake(PlayerControllerComponent self)
        {
            GameObject go = self.GetParent<Unit>().GetComponent<GameObjectComponent>().GameObject;
            self.Rigidbody2D = go.GetComponent<Rigidbody2D>();
            self.SpriteRenderer = go.GetComponent<SpriteRenderer>();
            self.Transform = go.GetComponent<Transform>();
            self.FootTransform =
                    (go.GetComponent<ReferenceCollector>().GetObject("FootPosition") as GameObject).GetComponent<Transform>();
            self.AnimatorComponent = self.GetParent<Unit>().GetComponent<AnimatorComponent>();

            // 获取InputSystem
            self.InputControl = new PlayerInputControl();
            self.InputControl.Enable();

            // TODO 从配置表中读初始数值
            self.speed = 5f;
            self.jumpForce = 20f;
            self.checkRaduis = 0.5f;
            self.groundLayer = LayerMask.GetMask("Ground");

            // 注册按键
            self.InputControl.Gameplay.Jump.started += self.Jump;
        }
    }

    public class PlayerControllerComponentUpdateSystem: UpdateSystem<PlayerControllerComponent>
    {
        public override void Update(PlayerControllerComponent self)
        {
            self.inputDirection = self.InputControl.Gameplay.Move.ReadValue<Vector2>();
            self.Move();
            self.Check();
            self.SetAnimation();
        }
    }

    [FriendClass(typeof (PlayerControllerComponent))]
    public static class PlayerControllerComponentSystem
    {
        /// <summary>
        /// 当角色objectActive设置未True时要调用这个方法
        /// </summary>
        /// <param name="self"></param>
        public static void OnEnable(this PlayerControllerComponent self)
        {
            self.InputControl.Enable();
        }

        public static void OnDisable(this PlayerControllerComponent self)
        {
            self.InputControl.Disable();
        }

        public static void Move(this PlayerControllerComponent self)
        {
            self.Rigidbody2D.velocity = new Vector2(self.inputDirection.x * self.speed, self.Rigidbody2D.velocity.y);

            if (self.inputDirection.x > 0)
            {
                self.faceDir = false;
            }

            if (self.inputDirection.x < 0)
            {
                self.faceDir = true;
            }

            // 人物翻转
            self.SpriteRenderer.flipX = self.faceDir;
        }

        public static void Jump(this PlayerControllerComponent self, InputAction.CallbackContext obj)
        {
            if (self.isGround)
            {
                self.Rigidbody2D.AddForce(self.Transform.up * self.jumpForce, ForceMode2D.Impulse);
            }
        }

        public static void Check(this PlayerControllerComponent self)
        {
            // 检测地面
            self.isGround = Physics2D.OverlapCircle(self.FootTransform.transform.position, self.checkRaduis, self.groundLayer);
        }

        public static void SetAnimation(this PlayerControllerComponent self)
        {
            self.AnimatorComponent.SetFloatValue("velocityX", Mathf.Abs(self.Rigidbody2D.velocity.x));
        }
    }
}