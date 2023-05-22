using System.Collections.Generic;

namespace ET.WE.Handler
{
    public class C2M_PlayerStateSynchHandler: AMActorLocationHandler<Unit, C2M_PlayerStateSynch>
    {
        protected override async ETTask Run(Unit unit, C2M_PlayerStateSynch message)
        {
            UnitComponent unitComponent = unit.GetParent<UnitComponent>();

            foreach (KeyValuePair<long, Entity> unitComponentChild in unitComponent.Children)
            {
                if (unitComponentChild.Key != unit.Id)
                {
                    // 转发玩家状态
                    MessageHelper.SendToClient((Unit)unitComponentChild.Value,
                        new M2C_PlayerStateSynch()
                        {
                            UnitId = unitComponentChild.Key,
                            X = message.X,
                            Y = message.Y,
                            InputDirectionX = message.InputDirectionX,
                            Jump = message.Jump
                        });
                }
            }

            await ETTask.CompletedTask;
        }
    }
}