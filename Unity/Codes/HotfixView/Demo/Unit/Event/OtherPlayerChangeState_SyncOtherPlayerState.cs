using System;
using ET.EventType;
using UnityEngine;

namespace ET
{
    [FriendClass(typeof (OtherPlayerControllerComponent))]
    public class OtherPlayerChangeState_SyncOtherPlayerState: AEventClass<OtherPlayerChangeState>
    {
        protected override void Run(object a)
        {
            EventType.OtherPlayerChangeState args = a as EventType.OtherPlayerChangeState;
            if (args.Unit == null)
            {
                return;
            }

            OtherPlayerControllerComponent otherPlayerControllerComponent = args.Unit.GetComponent<OtherPlayerControllerComponent>();
            
            // 位置修正
            float x = System.Math.Abs(args.X - otherPlayerControllerComponent.Transform.position.x);
            float y = System.Math.Abs(args.Y - otherPlayerControllerComponent.Transform.position.y);
            if (Math.Sqrt(x * x + y * y) > 1f)
            {
                Log.Debug("玩家坐标相差过大，修正!!!");
                otherPlayerControllerComponent.Transform.position = new Vector3(args.X, args.Y, 0);
            }
            
            otherPlayerControllerComponent.inputDirection.x = args.InputDirectionX;
            if (args.Jump)
            {
                otherPlayerControllerComponent.Jump();
            }
        }
    }
}