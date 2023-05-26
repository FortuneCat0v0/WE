using System.Collections.Generic;

namespace ET
{
    public class RoomAwakeSystem: AwakeSystem<Room>
    {
        public override void Awake(Room self)
        {
        }
    }

    public class RoomDestroySystem: DestroySystem<Room>
    {
        public override void Destroy(Room self)
        {
        }
    }

    [FriendClass(typeof (UnitGateComponent))]
    [FriendClass(typeof (Room))]
    public static class RoomSystem
    {
        /// <summary>
        /// 玩家加入房间
        /// </summary>
        /// <param name="self"></param>
        /// <param name="unit"></param>
        public static int JoinRoom(this Room self, Unit unit)
        {
            if (self.State == RoomState.Game)
            {
                // 已经开始游戏
                return ErrorCode.ERR_RoomPlayingError;
            }

            if (self.Units.TryGetValue(unit.Id, out Unit player))
            {
                return ErrorCode.ERR_RoomHavedPlayer;
            }

            if (self.Units.Count < self.maxPlayerNum)
            {
                self.Units.Add(unit.Id, unit);
                self.AddChild(unit);
                Log.Debug($"玩家:{unit.Id}加入房间:{self.Id}");

                // 通知客户端切换场景
                StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(self.DomainZone(), "Game");
                M2C_StartSceneChange m2CStartSceneChange =
                        new M2C_StartSceneChange() { SceneInstanceId = startSceneConfig.InstanceId, SceneName = "Home" };
                MessageHelper.SendToClient(unit, m2CStartSceneChange);
                // 通知客户端创建玩家
                M2C_CreateMyUnit m2CCreateUnits = new M2C_CreateMyUnit();
                m2CCreateUnits.Unit = UnitHelper.CreateUnitInfo(unit);
                MessageHelper.SendToClient(unit, m2CCreateUnits);
                // 通知客户端创建其他玩家
                foreach (KeyValuePair<long, Unit> keyValuePair in self.Units)
                {
                    if (keyValuePair.Key != unit.Id)
                    {
                        // 通知其他玩家客户端创建我
                        MessageHelper.SendToClient(keyValuePair.Value,
                            new M2C_CreateOtherUnit() { Unit = UnitHelper.CreateUnitInfo(unit) });
                        // 其我的客户端创建其他玩家
                        MessageHelper.SendToClient(unit,
                            new M2C_CreateOtherUnit() { Unit = UnitHelper.CreateUnitInfo(keyValuePair.Value) });
                    }
                }

                return ErrorCode.ERR_Success;
            }

            return ErrorCode.ERR_RoomIsFullError;
        }

        /// <summary>
        /// 玩家退出房间
        /// </summary>
        /// <param name="self"></param>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public static void ExitRoom(this Room self, long unitId)
        {
            self.Units.Remove(unitId);
            // 如果房间没人了，则销毁房间
            if (self.Units.Count <= 0)
            {
                self.GetParent<RoomComponent>().RemoveRoom(self.Id);
            }
        }

        /// <summary>
        /// 设置房间信息
        /// </summary>
        /// <param name="self"></param>
        public static void SetRoomInfo(this Room self)
        {
        }

        /// <summary>
        /// 获取房间玩家数量
        /// </summary>
        /// <param name="self"></param>
        public static int GetPlayerNum(this Room self)
        {
            return self.Units.Count;
        }

        /// <summary>
        /// 广播消息
        /// </summary>
        /// <param name="self"></param>
        /// <param name="message"></param>
        public static void Broadcast(this Room self, IActorMessage message)
        {
            foreach (Unit unit in self.Units.Values)
            {
                MessageHelper.SendActor(unit.GetComponent<UnitGateComponent>().GateSessionActorId, message);
            }
        }

        /// <summary>
        /// 广播消息，除了自己
        /// </summary>
        /// <param name="self"></param>
        /// <param name="message"></param>
        /// <param name="myId"></param>
        public static void BroadcastNoSelf(this Room self, IActorMessage message, long myId)
        {
            foreach (Unit unit in self.Units.Values)
            {
                if (unit.Id != myId)
                {
                    MessageHelper.SendActor(unit.GetComponent<UnitGateComponent>().GateSessionActorId, message);
                }
            }
        }

        public static RoomInfo ToProto(this Room self)
        {
            RoomInfo roomInfo = new RoomInfo();
            roomInfo.RoomId = self.Id;
            roomInfo.Pattern = "普通模式";
            roomInfo.NowNum = self.Units.Count;
            roomInfo.MaxNum = self.maxPlayerNum;
            roomInfo.RoomState = (int)self.State;
            roomInfo.Intro = "这是一个测试房间";
            return roomInfo;
        }
    }
}