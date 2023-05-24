namespace ET
{
    public class ChatInfoDestroySystem: DestroySystem<ChatInfo>
    {
        public override void Destroy(ChatInfo self)
        {
            self.Message = null;
            self.Name    = null;
        }
    }
}