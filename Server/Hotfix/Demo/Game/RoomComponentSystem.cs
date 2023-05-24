using System.Collections.Generic;
using System.Linq;

namespace ET
{
    public class RoomComponentAwakeSystem: AwakeSystem<RoomComponent>
    {
        public override void Awake(RoomComponent self)
        {
        }
    }

    public class RoomComponentDestroySystem: DestroySystem<RoomComponent>
    {
        public override void Destroy(RoomComponent self)
        {
            foreach (var room in self.Rooms.Values)
            {
                room?.Dispose();
            }

            self.Rooms.Clear();
        }
    }

    [FriendClass(typeof (RoomComponent))]
    [FriendClass(typeof (Room))]
    public static class RoomComponentSystem
    {
        /// <summary>
        /// 添加房间,房主加入,并设置房主Id
        /// </summary>
        /// <param name="self"></param>
        /// <param name="hostId"></param>
        public static Room CreateRoom(this RoomComponent self, Unit unit)
        {
            Room room = self.AddChild<Room>();
            room.hostId = unit.Id;
            // 给房间添加基本的组件

            self.Rooms.Add(room.Id, room);

            room.Units.Add(unit.Id, unit);
            room.AddChild(unit);
            Log.Debug($"玩家:{unit.Id}创建了房间:{room.Id}");
            return room;
        }

        /// <summary>
        /// 获取房间
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Room GetRoom(this RoomComponent self, long id)
        {
            Room room;
            self.Rooms.TryGetValue(id, out room);
            return room;
        }

        /// <summary>
        /// 获取所有房间
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static List<Room> GetAllRooms(this RoomComponent self)
        {
            return self.Rooms.Values.ToList();
        }

        /// <summary>
        /// 移除房间
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static void RemoveRoom(this RoomComponent self, long id)
        {
            Room room = self.GetRoom(id);
            self.Rooms.Remove(id);
            room.Dispose();
            Log.Debug($"销毁房间:{id}");
        }
    }
}