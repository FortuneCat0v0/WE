using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    [ChildType(typeof(RoleInfo))]
    public class RoleInfosComponent : Entity ,IAwake,IDestroy
    {
        public List<RoleInfo> RoleInfos = new List<RoleInfo>();
        public long CurrentRoleId = 0;
    }
}