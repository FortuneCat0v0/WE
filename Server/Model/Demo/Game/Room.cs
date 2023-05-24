using System.Collections.Generic;

namespace ET
{
    /// <summary>
    /// 房间状态
    /// </summary>
    public enum RoomState: byte
    {
        Idle,
        Ready,
        Game
    }

    [ChildType(typeof (Unit))]
    public class Room: Entity, IAwake, IDestroy
    {
        // 房主Id
        public long hostId;

        public Dictionary<long, Unit> Units = new Dictionary<long, Unit>();

        //房间状态
        public RoomState State { get; set; } = RoomState.Idle;

        // 房间设置
        public int maxPlayerNum = 5;

        public M2C_PlayerStateSynch M2C_PlayerStateSynch = new M2C_PlayerStateSynch();
    }
}