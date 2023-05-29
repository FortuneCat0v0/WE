using System;

namespace ET.Demo.Game.Handler
{
    public class C2M_RequestTransferLevelHandler: AMActorLocationRpcHandler<Unit, C2M_RequestTransferLevel, M2C_RequestTransferLevel>
    {
        protected override async ETTask Run(Unit unit, C2M_RequestTransferLevel request, M2C_RequestTransferLevel response, Action reply)
        {
            Room room = unit.GetParent<Room>();
            int errorCode = room.TransferLevel(request.LevelName);
            if (errorCode != ErrorCode.ERR_Success)
            {
                Log.Error(errorCode.ToString());
            }

            response.Error = errorCode;
            reply();
            await ETTask.CompletedTask;
        }
    }
}