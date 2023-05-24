using System;
using System.Collections.Generic;

namespace ET
{
    public class C2M_RequestRoomInfosHandler: AMActorLocationRpcHandler<Unit, C2M_RequestRoomInfos, M2C_RequestRoomInfos>
    {
        protected override async ETTask Run(Unit unit, C2M_RequestRoomInfos request, M2C_RequestRoomInfos response, Action reply)
        {
            Room room = unit.GetParent<Room>();
            RoomComponent roomComponent = room.GetParent<RoomComponent>();
            List<Room> rooms = roomComponent.GetAllRooms();

            foreach (Room var in rooms)
            {
                response.RoomInfos.Add(var.ToProto());
            }

            reply();
            await ETTask.CompletedTask;
        }
    }
}