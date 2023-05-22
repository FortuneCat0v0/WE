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
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit unit = request.Unit;

            unitComponent.AddChild(unit);
            unitComponent.Add(unit);

            unit.AddComponent<UnitDBSaveComponent>();

            foreach (Entity entity in request.Entitys)
            {
                unit.AddComponent(entity);
            }

            // unit.AddComponent<MoveComponent>();
            // unit.AddComponent<PathfindingComponent, string>(scene.Name);
            // unit.Position = new Vector3(-10, 0, -10);

            unit.AddComponent<MailBoxComponent>();

            // 通知客户端创建My Unit
            M2C_CreateMyUnit m2CCreateUnits = new M2C_CreateMyUnit();
            m2CCreateUnits.Unit = UnitHelper.CreateUnitInfo(unit);
            MessageHelper.SendToClient(unit, m2CCreateUnits);

            // 加入aoi
            // unit.AddComponent<AOIEntity, int, Vector3>(9 * 1000, unit.Position);

            // TODO 测试
            // 通知其他玩家，有玩家进入，创建其他玩家对象
            foreach (KeyValuePair<long, Entity> unitComponentChild in unitComponent.Children)
            {
                if (unitComponentChild.Key != unit.Id)
                {
                    // 加入其他玩家
                    MessageHelper.SendToClient((Unit)unitComponentChild.Value,
                        new M2C_CreateOtherUnit() { Unit = UnitHelper.CreateUnitInfo(unit) });
                    // 其他玩家进入我
                    MessageHelper.SendToClient(unit,
                        new M2C_CreateOtherUnit() { Unit = UnitHelper.CreateUnitInfo((Unit)unitComponentChild.Value) });
                }
            }

            response.NewInstanceId = unit.InstanceId;

            reply();
        }
    }
}