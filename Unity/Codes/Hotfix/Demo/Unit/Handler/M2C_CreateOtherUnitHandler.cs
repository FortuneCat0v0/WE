namespace ET
{
    public class M2C_CreateOtherUnitHandler: AMHandler<M2C_CreateOtherUnit>
    {
        protected override void Run(Session session, M2C_CreateOtherUnit message)
        {
            CurrentScenesComponent currentScenesComponent = session.ZoneScene().GetComponent<CurrentScenesComponent>();
            Unit unit = UnitFactory.CreateOtherPlayer(currentScenesComponent.Scene, message.Unit, message.Name);
        }
    }
}