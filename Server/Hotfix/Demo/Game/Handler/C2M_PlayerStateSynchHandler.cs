using System.Collections.Generic;

namespace ET.WE.Handler
{
    [FriendClass(typeof (Room))]
    public class C2M_PlayerStateSynchHandler: AMActorLocationHandler<Unit, C2M_PlayerStateSynch>
    {
        protected override async ETTask Run(Unit unit, C2M_PlayerStateSynch message)
        {
            Room room = unit.GetParent<Room>();
            room.M2C_PlayerStateSynch.UnitId = unit.Id;
            room.M2C_PlayerStateSynch.X = message.X;
            room.M2C_PlayerStateSynch.Y = message.Y;
            room.M2C_PlayerStateSynch.InputDirectionX = message.InputDirectionX;
            room.M2C_PlayerStateSynch.Jump = message.Jump;

            room.BroadcastNoSelf(room.M2C_PlayerStateSynch, unit.Id);

            await ETTask.CompletedTask;
        }
    }
}