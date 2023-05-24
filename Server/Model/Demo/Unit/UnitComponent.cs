namespace ET
{
    [ComponentOf()]
    [ChildType(typeof (Unit))]
    public class UnitComponent: Entity, IAwake, IDestroy
    {
    }
}