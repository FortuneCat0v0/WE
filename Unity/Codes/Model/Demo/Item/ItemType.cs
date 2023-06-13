namespace ET
{
    /// <summary>
    /// 物品项类型
    /// </summary>
    public enum ItemType
    {
        Seed            = 0, //种子
        Commodity       = 1, //商品
        Furniture       = 2, //家具
        HoeTool         = 3, //锄头
        ChopTool        = 4, //斧头
        BreakTool       = 5, //衣服
        ReapTool        = 6, //镰刀
        WaterTool       = 7, //水壶
        CollectTool     = 8, //搜集
        ReapableScenery = 9
    }

    /// <summary>
    /// 物品操作指令
    /// </summary>
    public enum ItemOp
    {
        Add = 0,  //增加物品
        Remove = 1 //移除物品
    }


    /// <summary>
    /// 物品容器类型
    /// </summary>
    public enum ItemContainerType
    {
        Bag = 0,  //背包容器
        RoleInfo = 1, //游戏角色装配容器
    }
    
}