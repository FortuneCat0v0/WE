using UnityEngine;

namespace ET
{
    public class PlayerToHallInteractionComponentAwakeSystem: AwakeSystem<PlayerToHallInteractionComponent, GameObject>
    {
        public override void Awake(PlayerToHallInteractionComponent self, GameObject go)
        {
            ColliderCallback colliderCallback = go.GetComponent<ColliderCallback>();

            // 监听触发
            colliderCallback.OnTriggerEnter2DAction = self.OnTriggerEnter2D;
            colliderCallback.OnTriggerExit2DAction = self.OnTriggerExit2D;
        }
    }

    public static class PlayerToHallInteractionComponentSystem
    {
        /// <summary>
        /// 进入碰撞
        /// </summary>
        /// <param name="self"></param>
        /// <param name="collider"></param>
        public static void OnTriggerEnter2D(this PlayerToHallInteractionComponent self, Collider2D collider)
        {
            if (collider.gameObject.tag.Equals("TriggerItem"))
            {
                Log.Debug("碰撞的物体是" + collider.gameObject.name);
                switch (collider.gameObject.name)
                {
                    case "Level_01":
                        break;
                    case "Level_02":
                        break;
                    case "Level_03":
                        break;
                    case "Level_04":
                        break;
                    case "Level_05":
                        break;
                    case "Level_06":
                        break;
                }
            }
        }

        /// <summary>
        /// 退出碰撞
        /// </summary>
        /// <param name="self"></param>
        /// <param name="collider"></param>
        public static void OnTriggerExit2D(this PlayerToHallInteractionComponent self, Collider2D collider)
        {
            Log.Debug("退出了触发碰撞");
        }
    }
}