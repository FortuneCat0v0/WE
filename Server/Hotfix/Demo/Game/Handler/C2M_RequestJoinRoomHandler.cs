using System;

namespace ET.Demo.Game.Handler
{
    public class C2M_RequestJoinRoomHandler: AMActorLocationRpcHandler<Unit, C2M_RequestJoinRoom, M2C_RequestJoinRoom>
    {
        protected override async ETTask Run(Unit unit, C2M_RequestJoinRoom request, M2C_RequestJoinRoom response, Action reply)
        {
            RoomComponent roomComponent = unit.GetParent<Room>().GetParent<RoomComponent>();
            Room room = roomComponent.GetRoom(request.RoomId);

            if (room != null)
            {
                response.Error = room.JoinRoom(unit);
            }
            else
            {
                response.Error = ErrorCode.ERR_RoomIsNull;
            }

            reply();
            await ETTask.CompletedTask;
        }
    }
}