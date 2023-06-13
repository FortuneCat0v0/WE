using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    [ActorMessageHandler]
    public class M2M_UnitTransferRequestHandler: AMActorRpcHandler<Scene, M2M_UnitTransferRequest, M2M_UnitTransferResponse>
    {
        protected override async ETTask Run(Scene scene, M2M_UnitTransferRequest request, M2M_UnitTransferResponse response, Action reply)
        {
            await ETTask.CompletedTask;
            // RoomComponent roomComponent = scene.GetComponent<RoomComponent>();
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();

            Unit unit = request.Unit;
            unitComponent.AddChild(unit);
            // Room room = roomComponent.CreateRoom(unit);

            unit.AddComponent<UnitDBSaveComponent>();
            
            foreach (Entity entity in request.Entitys)
            {
                unit.AddComponent(entity);
            }
            
            unit.AddComponent<MailBoxComponent>();
            
            // 通知客户端创建My Unit
            M2C_CreateMyUnit m2CCreateUnits = new M2C_CreateMyUnit();
            m2CCreateUnits.Unit = UnitHelper.CreateUnitInfo(unit);
            MessageHelper.SendToClient(unit, m2CCreateUnits);

            //通知客户端同步背包信息
            ItemUpdateNoticeHelper.SyncAllBagItems(unit);
            
            response.NewInstanceId = unit.InstanceId;

            reply();
        }
    }
}