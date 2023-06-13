using UnityEngine;

namespace ET
{
    public class PlayerInteractionComponentAwakeSystem: AwakeSystem<PlayerInteractionComponent, GameObject>
    {
        public override void Awake(PlayerInteractionComponent self, GameObject go)
        {
            ColliderCallback colliderCallback = go.GetComponent<ColliderCallback>();

            // 监听触发
            colliderCallback.OnTriggerEnter2DAction = self.OnTriggerEnter2D;
            colliderCallback.OnTriggerExit2DAction = self.OnTriggerExit2D;
        }
    }

    public static class PlayerInteractionComponentSystem
    {
        /// <summary>
        /// 进入碰撞
        /// </summary>
        /// <param name="self"></param>
        /// <param name="collider"></param>
        public static void OnTriggerEnter2D(this PlayerInteractionComponent self, Collider2D collider)
        {
            GameObject go = collider.gameObject;
            if (go.tag.Equals("WorldItem"))
            {
                Log.Debug("碰撞的物体是" + go.name);
                long unitId = go.GetComponent<UnitId>().id;
                // TODO 发送消息到服务端
            }
        }

        /// <summary>
        /// 退出碰撞
        /// </summary>
        /// <param name="self"></param>
        /// <param name="collider"></param>
        public static void OnTriggerExit2D(this PlayerInteractionComponent self, Collider2D collider)
        {
            Log.Debug("退出了触发碰撞");
        }
    }
}