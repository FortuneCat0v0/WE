using System.Collections.Generic;

namespace ET
{
    /// <summary>
    /// 房间管理组件
    /// </summary>
    [ComponentOf(typeof (Scene))]
    [ChildType(typeof (Room))]
    public class RoomComponent: Entity, IAwake, IDestroy
    {
        public Dictionary<long, Room> Rooms = new Dictionary<long, Room>();
    }
}