using System.Collections.Generic;

namespace ET
{

    public interface IUnitCache
    {
        
    }
    
    
    public class UnitCache : Entity,IAwake,IDestroy
    {
        public string key;

        /// <summary>
        /// UnitID身上的实体
        /// </summary>
        public Dictionary<long, Entity> CacheCompoenntsDictionary = new Dictionary<long, Entity>();
    }
}