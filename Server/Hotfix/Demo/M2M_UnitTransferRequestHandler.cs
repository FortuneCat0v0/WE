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
            unit.AddComponent<MailBoxComponent>();
            foreach (Entity entity in request.Entitys)
            {
                unit.AddComponent(entity);
            }

            // 通知客户端创建My Unit
            M2C_CreateMyUnit m2CCreateUnits = new M2C_CreateMyUnit();
            m2CCreateUnits.Unit = UnitHelper.CreateUnitInfo(unit);
            MessageHelper.SendToClient(unit, m2CCreateUnits);

            response.NewInstanceId = unit.InstanceId;

            reply();
        }
    }
}