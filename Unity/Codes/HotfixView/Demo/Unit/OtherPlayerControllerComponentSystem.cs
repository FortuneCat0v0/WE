using UnityEngine;

namespace ET
{
    public class OtherPlayerControllerComponentAwakeSystem: AwakeSystem<OtherPlayerControllerComponent>
    {
        public override void Awake(OtherPlayerControllerComponent self)
        {
            GameObject go = self.GetParent<Unit>().GetComponent<GameObjectComponent>().GameObject;
            self.Rigidbody2D = go.GetComponent<Rigidbody2D>();
            self.SpriteRenderer = go.GetComponent<SpriteRenderer>();
            self.Transform = go.GetComponent<Transform>();
            self.FootTransform =
                    (go.GetComponent<ReferenceCollector>().GetObject("FootPosition") as GameObject).GetComponent<Transform>();
            self.AnimatorComponent = self.GetParent<Unit>().GetComponent<AnimatorComponent>();

            // TODO 从配置表中读初始数值
            self.speed = 5f;
            self.jumpForce = 20f;
            self.checkRaduis = 0.5f;
            self.groundLayer = LayerMask.GetMask("Ground");
        }
    }

    public class OtherPlayerControllerComponentUpdateSystem: UpdateSystem<OtherPlayerControllerComponent>
    {
        public override void Update(OtherPlayerControllerComponent self)
        {
            self.Move();
            self.Check();
            self.SetAnimation();
        }
    }

    public class OtherPlayerControllerComponentDestorySystem: DestroySystem<OtherPlayerControllerComponent>
    {
        public override void Destroy(OtherPlayerControllerComponent self)
        {
        }
    }

    [FriendClass(typeof (OtherPlayerControllerComponent))]
    public static class OtherPlayerControllerComponentSystem
    {
        public static void Move(this OtherPlayerControllerComponent self)
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

        public static void Jump(this OtherPlayerControllerComponent self)
        {
            if (self.isGround)
            {
                self.Rigidbody2D.AddForce(self.Transform.up * self.jumpForce, ForceMode2D.Impulse);
            }
        }

        public static void Check(this OtherPlayerControllerComponent self)
        {
            // 检测地面
            self.isGround = Physics2D.OverlapCircle(self.FootTransform.transform.position, self.checkRaduis, self.groundLayer);
        }

        public static void SetAnimation(this OtherPlayerControllerComponent self)
        {
            self.AnimatorComponent.SetFloatValue("velocityX", Mathf.Abs(self.Rigidbody2D.velocity.x));
        }
    }
}