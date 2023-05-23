using ET.EventType;

namespace ET
{
    public class M2C_PlayerStateSynchHandler: AMHandler<M2C_PlayerStateSynch>
    {
        protected override void Run(Session session, M2C_PlayerStateSynch message)
        {
            Scene currentScene = session.DomainScene().CurrentScene();
            UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();

            Unit otherUnit = unitComponent.Get(message.UnitId);
            if (otherUnit != null)
            {
                OtherPlayerChangeState.Instance.Unit = otherUnit;
                OtherPlayerChangeState.Instance.X = message.X;
                OtherPlayerChangeState.Instance.Y = message.Y;
                OtherPlayerChangeState.Instance.InputDirectionX = message.InputDirectionX;
                OtherPlayerChangeState.Instance.Jump = message.Jump;
                EventSystem.Instance.PublishClass(OtherPlayerChangeState.Instance);
            }
        }
    }
}