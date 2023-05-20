using System;
using UnityEngine;

namespace ET
{
    public static class UnitFactory
    {
        public static Unit Create(Scene scene, long id, UnitType unitType)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            switch (unitType)
            {
                case UnitType.Player:
                {
                    Unit unit = unitComponent.AddChildWithId<Unit, int>(id, 1001);
                    //ChildType测试代码 取消注释 编译Server.hotfix 可发现报错
                    //unitComponent.AddChild<Player, string>("Player");
                    NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
                    foreach (var config in PlayerNumericConfigCategory.Instance.GetAll())
                    {
                        if (config.Value.BaseValue == 0)
                        {
                            continue;
                        }

                        if (config.Key < 3000) //小于3000的值都用加成属性推导
                        {
                            int baseKey = config.Key * 10 + 1;
                            numericComponent.SetNoEvent(baseKey, config.Value.BaseValue);
                        }
                        else
                        {
                            //大于3000的值 直接使用
                            numericComponent.SetNoEvent(config.Key, config.Value.BaseValue);
                        }
                    }

                    unitComponent.Add(unit);
                    return unit;
                }
                default:
                    throw new Exception($"not such unit type: {unitType}");
            }
        }
    }
}