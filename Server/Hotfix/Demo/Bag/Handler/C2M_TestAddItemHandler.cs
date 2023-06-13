namespace ET
{
    public class C2M_TestAddItemHandler: AMActorLocationHandler<Unit, C2M_TestAddItem>
    {
        protected override async ETTask Run(Unit unit, C2M_TestAddItem message)
        {
            BagHelper.AddItemByConfigId(unit, message.ItemConfig);
            await ETTask.CompletedTask;
        }
    }
}