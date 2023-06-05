using UnityEngine;
using UnityEngine.InputSystem;

namespace ET
{
    public class PlayerAwakeSystem: AwakeSystem<Player>
    {
        public override void Awake(Player self)
        {
            self.Awake();
        }
    }

    public class PlayerUpdateSystem: UpdateSystem<Player>
    {
        public override void Update(Player self)
        {
            self.Update();
        }
    }

    public class PlayerFixedUpdayeSystem: FixedUpdateSystem<Player>
    {
        public override void FixedUpdate(Player self)
        {
            self.FixedUpdate();
        }
    }

    public class PlayerDestroySystem: DestroySystem<Player>
    {
        public override void Destroy(Player self)
        {
            self.Destroy();
        }
    }

    [FriendClass(typeof (Player))]
    public static class PlayerSystem
    {
        public static void Awake(this Player self)
        {
            GameObject go = self.GetParent<Unit>().GetComponent<GameObjectComponent>().GameObject;
            self.Rigidbody2D = go.GetComponent<Rigidbody2D>();

            // 获取InputSystem
            self.InputControl = new PlayerInputControl();
            self.InputControl.Enable();

            self.speed = 10f;
        }

        public static void Update(this Player self)
        {
            self.PlayerInput();
        }

        public static void FixedUpdate(this Player self)
        {
            self.Movement();
        }

        public static void Destroy(this Player self)
        {
        }

        public static void PlayerInput(this Player self)
        {
            Vector2 input = self.InputControl.Gameplay.Move.ReadValue<Vector2>();
            if (input.x != 0 && input.y != 0)
            {
                input = input * 0.6f;
            }

            self.movementInput = input;
        }

        public static void Movement(this Player self)
        {
            self.Rigidbody2D.MovePosition(self.Rigidbody2D.position + self.movementInput * self.speed * Time.deltaTime);
        }
    }
}