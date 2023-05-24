namespace ET
{
    public class ChatInfoUnitDestroySystem : DestroySystem<ChatInfoUnit>
    {
        public override void Destroy(ChatInfoUnit self)
        {
            self.Name = null;
            self.GateSessionActorId = 0;
        }
    }
}