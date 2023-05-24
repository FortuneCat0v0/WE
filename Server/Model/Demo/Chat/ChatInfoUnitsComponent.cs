using System;
using System.Collections.Generic;

namespace ET
{
    [ChildType(typeof(ChatInfoUnit))]
    [ComponentOf(typeof(Scene))]
    public class ChatInfoUnitsComponent : Entity,IAwake,IDestroy
    {
        public  Dictionary<long, ChatInfoUnit> ChatInfoUnitsDict = new Dictionary<long, ChatInfoUnit>();
    }
}