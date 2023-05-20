namespace ET
{
    public enum PlayerState
    {
        Disconnect,
        Gate,
        Game,
    }

    public sealed class Player: Entity, IAwake<string>, IAwake<long, long>, IDestroy
    {
        public long AccountId { get; set; }

        /// <summary>
        /// 与RoleId相同
        /// </summary>
        public long UnitId { get; set; }

        public PlayerState PlayerState { get; set; }

        public Session ClientSession { get; set; }

        public long ChatInfoInstanceId { get; set; }

        public bool IsMatching { get; set; }

        public long GamerInstanceId { get; set; }
    }
}