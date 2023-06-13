namespace ET
{
    
    public class BagComponentDestorySystem : DestroySystem<BagComponent>
    {
        public override void Destroy(BagComponent self)
        {
            self.Clear();
        }
    }

    [FriendClass(typeof(BagComponent))]
    public static class BagComponentSystem
    {
        /// <summary>
        /// 是否达到最大负载
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsMaxLoad(this BagComponent self)
        {
            NumericComponent numericComponent = UnitHelper.GetMyUnitNumericComponent(self.ZoneScene().CurrentScene());
            return self.ItemsDict.Count == numericComponent[NumericType.MaxBagCapacity];
        }
        
        
        public static void Clear(this BagComponent self)
        {
              ForeachHelper.Foreach(self.ItemsDict,(long id, Item item)=>
              {
                  item?.Dispose();
              });
              self.ItemsDict.Clear();
              self.ItemsMap.Clear();
        }
        
        
        public static int GetItemCountByItemType(this BagComponent self, ItemType itemType)
        {
            if (!self.ItemsMap.ContainsKey((int)itemType))
            {
                return 0;
            }
            return self.ItemsMap[(int)itemType].Count;
        }


        public static void AddItem(this BagComponent self, Item item)
        {
            self.AddChild(item);
            self.ItemsDict.Add(item.Id,item);
            self.ItemsMap.Add(item.Config.Type,item);
        }

        public static void RemoveItem(this BagComponent self, Item item)
        {
            if (item == null)
            {
                Log.Error("bag item is null");
                return; 
            }
            
            self.ItemsDict.Remove(item.Id);
            self.ItemsMap.Remove(item.Config.Type, item);
            item?.Dispose();
        }

        public static Item GetItemById(this BagComponent self, long itemId)
        {
            if (self.ItemsDict.TryGetValue(itemId,out Item item))
            {
                return item;
            }
            return null;
        }
    }
}