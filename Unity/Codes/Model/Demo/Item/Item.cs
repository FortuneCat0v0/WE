#if SERVER
using MongoDB.Bson.Serialization.Attributes;
#endif

namespace ET
{
#if SERVER
    public class Item : Entity,IAwake<int>,IDestroy,ISerializeToEntity
#else    
    public class Item : Entity,IAwake<int>,IDestroy
#endif
    {
        //物品配置ID
        public int ConfigId = 0;

        /// <summary>
        /// 物品品质
        /// </summary>
        public int Quality  = 0;
        
#if SERVER
        [BsonIgnore]
#endif
        //物品配置数据
        public ItemConfig Config => ItemConfigCategory.Instance.Get(ConfigId);
        
    }
}