using System;
using UnityEngine;

namespace ET
{
    /// <summary>
    /// 关卡传送门的Collider事件的回调脚本
    /// </summary>
    public class ColliderCallback: MonoBehaviour
    {
        public Action<Collider2D> OnTriggerEnter2DAction;
        public Action<Collider2D> OnTriggerExit2DAction;

        private void OnTriggerEnter2D(Collider2D other)
        {
            this.OnTriggerEnter2DAction?.Invoke(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            this.OnTriggerExit2DAction?.Invoke(other);
        }
    }
}