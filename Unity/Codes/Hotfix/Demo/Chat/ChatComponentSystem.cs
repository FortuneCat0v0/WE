namespace ET
{
    
    public class ChatComponentDestroySystem : DestroySystem<ChatComponent>
    {
        public override void Destroy(ChatComponent self)
        {
            foreach (var chatInfo in self.ChatMessageQueue)
            {
                chatInfo?.Dispose();
            }
            self.ChatMessageQueue.Clear();
        }
    }

    [FriendClassAttribute(typeof(ET.ChatComponent))]
    public static class ChatComponentSystem
    {
        
        public static void Add(this ChatComponent self,ChatInfo chatInfo)
        {
            //客户端最大值留存100条世界聊天信息
            if (self.ChatMessageQueue.Count >= 100)
            {
              ChatInfo  oldChatInfo =  self.ChatMessageQueue.Dequeue();
              oldChatInfo?.Dispose();
            }
            self.ChatMessageQueue.Enqueue(chatInfo);
        }
        
        public static int GetChatMessageCount(this ChatComponent self)
        {
            return self.ChatMessageQueue.Count;
        }

        public static ChatInfo GetChatMessageByIndex(this ChatComponent self, int index)
        {
            int tempIndex = 0;
            foreach (var chatInfo in self.ChatMessageQueue)
            {
                if (tempIndex == index)
                {
                    return chatInfo;
                }
                ++tempIndex;
            }
            return null;
        }
    }
}