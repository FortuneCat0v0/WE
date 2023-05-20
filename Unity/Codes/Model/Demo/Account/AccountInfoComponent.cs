namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class AccountInfoComponent : Entity,IAwake,IDestroy
    {
        public string Token;
        public long AccountId;
        public string RealmKey;
        public string RealmAddress;
    }
}