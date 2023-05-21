using UnityEngine;
using UnityEngine.InputSystem;

namespace ET
{
    public class PlayerControllerComponentAwakeSystem: AwakeSystem<PlayerControllerComponent>
    {
        public override void Awake(PlayerControllerComponent self)
        {
            self.InputControl = new PlayerInputControl();
            self.InputControl.Enable();
            // TODO 从配置表中读初始数值

            self.InputControl.Gameplay.Jump.started += self.Jump;
        }
    }

    public class PlayerControllerComponentUpdateSystem: UpdateSystem<PlayerControllerComponent>
    {
        public override void Update(PlayerControllerComponent self)
        {
            self.inputDirection = self.InputControl.Gameplay.Move.ReadValue<Vector2>();
            self.Move();
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
            self.Rigidbody2D.AddForce(self.Transform.up * self.jumpForce, ForceMode2D.Impulse);
        }
    }
}