using System.Collections.Generic;

namespace ET
{
    [ChildType(typeof(ChatInfo))]
    [ComponentOf(typeof(Scene))]
    public class ChatComponent : Entity,IAwake,IDestroy
    {
        public Queue<ChatInfo> ChatMessageQueue = new Queue<ChatInfo>(100);
    }
}