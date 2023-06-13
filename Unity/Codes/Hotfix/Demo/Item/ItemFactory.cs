namespace ET
{
    public static class ItemFactory
    {
        public static Item Create( Entity self,int configId)
        {
            Item item = self.AddChild<Item,int>(configId);
            return item;
        }
        
        public static Item Create( Entity self,ItemInfo itemInfo)
        {
            Item item = self?.AddChild<Item,int>(itemInfo.ItemConfigId);
            item?.FromMessage(itemInfo);
            return item;
        }
    }
}