using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    [ChildType(typeof(UnitCache))]
    public class UnitCacheComponent : Entity,IAwake,IDestroy
    {
        public Dictionary<string, UnitCache> UnitCaches = new Dictionary<string, UnitCache>();

        //所有继承ICache的类型
        public List<string> UnitCacheKeyList = new List<string>();

    }
}