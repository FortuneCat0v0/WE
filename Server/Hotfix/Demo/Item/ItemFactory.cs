using System;

namespace ET
{
    [FriendClass(typeof(Item))]
    public static class ItemFactory
    {
        public static Item Create(Entity parent, int configId)
        {
            if ( !ItemConfigCategory.Instance.Contain(configId))
            {
                Log.Error($"当前所创建的物品id 不存在: {configId}");
                return null;
            }
            Item item = parent.AddChild<Item, int>(configId);
            // item.RandomQuality();
            // AddComponentByItemType(item);
            return item;
        }

        public static void AddComponentByItemType(Item item)
        {
            switch ((ItemType)item.Config.Type)
            {
                case ItemType.Seed:
                {
                    item.AddComponent<EquipInfoComponent>();
                    break;
                }
                case ItemType.Commodity:
                {
                    item.AddComponent<EquipInfoComponent>();
                    break;
                }
                case ItemType.Furniture:
                {
                    item.AddComponent<EquipInfoComponent>();
                    break;
                }
                case ItemType.HoeTool:
                {
                    item.AddComponent<EquipInfoComponent>();
                     break;
                }
                case ItemType.ChopTool:
                {
                    item.AddComponent<EquipInfoComponent>();
                    break;               
                }
                case ItemType.BreakTool:
                {
                    item.AddComponent<EquipInfoComponent>();
                    break;                 
                }
                case ItemType.ReapTool:
                {
                    item.AddComponent<EquipInfoComponent>();
                    break;
                }
                case ItemType.WaterTool:
                {
                    item.AddComponent<EquipInfoComponent>();
                    break;
                }
                case ItemType.CollectTool:
                {
                    item.AddComponent<EquipInfoComponent>();
                    break;
                }
                case ItemType.ReapableScenery:
                {
                    item.AddComponent<EquipInfoComponent>();
                    break;
                }
                
            }
        }

      
        
    }
}