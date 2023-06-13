using System;
using UnityEngine;

namespace ET
{
    public static class UnitFactory
    {
        public static Unit CreatePlayer(Scene currentScene, UnitInfo unitInfo)
        {
            Log.Debug("开始创建本地玩家");
            UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChildWithId<Unit, int>(unitInfo.UnitId, unitInfo.ConfigId);
            unitComponent.Add(unit);

            // unit.Position = new Vector3(unitInfo.X, unitInfo.Y, unitInfo.Z);
            // unit.Forward = new Vector3(unitInfo.ForwardX, unitInfo.ForwardY, unitInfo.ForwardZ);

            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
            for (int i = 0; i < unitInfo.Ks.Count; ++i)
            {
                numericComponent.Set(unitInfo.Ks[i], unitInfo.Vs[i]);
            }

            unit.AddComponent<MoveComponent>();
            if (unitInfo.MoveInfo != null)
            {
                if (unitInfo.MoveInfo.X.Count > 0)
                {
                    using (ListComponent<Vector3> list = ListComponent<Vector3>.Create())
                    {
                        list.Add(unit.Position);
                        for (int i = 0; i < unitInfo.MoveInfo.X.Count; ++i)
                        {
                            list.Add(new Vector3(unitInfo.MoveInfo.X[i], unitInfo.MoveInfo.Y[i], unitInfo.MoveInfo.Z[i]));
                        }

                        unit.MoveToAsync(list).Coroutine();
                    }
                }
            }

            unit.AddComponent<ObjectWait>();

            // unit.AddComponent<XunLuoPathComponent>();

            Game.EventSystem.PublishAsync(new EventType.AfterPlayerCreate() { Unit = unit }).Coroutine();
            return unit;
        }

        public static Unit CreateOtherPlayer(Scene currentScene, UnitInfo unitInfo, string name)
        {
            Log.Debug("开始创建其它玩家");
            UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
            if (unitComponent.Get(unitInfo.UnitId) != null)
            {
                Log.Debug("已经存在Unit");
                return null;
            }

            Unit unit = unitComponent.AddChildWithId<Unit, int>(unitInfo.UnitId, unitInfo.ConfigId);
            unitComponent.Add(unit);

            // unit.Position = new Vector3(unitInfo.X, unitInfo.Y, unitInfo.Z);
            // unit.Forward = new Vector3(unitInfo.ForwardX, unitInfo.ForwardY, unitInfo.ForwardZ);

            // NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
            // for (int i = 0; i < unitInfo.Ks.Count; ++i)
            // {
            //     numericComponent.Set(unitInfo.Ks[i], unitInfo.Vs[i]);
            // }

            // unit.AddComponent<MoveComponent>();
            // if (unitInfo.MoveInfo != null)
            // {
            //     if (unitInfo.MoveInfo.X.Count > 0)
            //     {
            //         using (ListComponent<Vector3> list = ListComponent<Vector3>.Create())
            //         {
            //             list.Add(unit.Position);
            //             for (int i = 0; i < unitInfo.MoveInfo.X.Count; ++i)
            //             {
            //                 list.Add(new Vector3(unitInfo.MoveInfo.X[i], unitInfo.MoveInfo.Y[i], unitInfo.MoveInfo.Z[i]));
            //             }
            //
            //             unit.MoveToAsync(list).Coroutine();
            //         }
            //     }
            // }
            //
            // unit.AddComponent<ObjectWait>();

            // unit.AddComponent<XunLuoPathComponent>();

            Game.EventSystem.PublishAsync(new EventType.AfterOtherPlayerCreate { Unit = unit, Name = name }).Coroutine();
            return unit;
        }

        public static Unit CreateWorldItem(Scene currentScene, UnitInfo unitInfo)
        {
            Log.Debug("开始创建物品");
            UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChildWithId<Unit, int>(unitInfo.UnitId, unitInfo.ConfigId);
            unitComponent.Add(unit);
            Game.EventSystem.PublishAsync(new EventType.AfterWorldItemCreate() { Unit = unit }).Coroutine();
            return unit;
        }
    }
}