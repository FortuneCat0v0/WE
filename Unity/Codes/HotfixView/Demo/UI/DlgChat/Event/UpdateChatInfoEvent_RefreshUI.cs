using ET.EventType;

namespace ET
{
    public class UpdateChatInfoEvent_RefreshUI : AEvent<UpdateChatInfo>
    {
        protected override void Run(UpdateChatInfo args)
        {
            args.ZoneScene.GetComponent<UIComponent>()?.GetDlgLogic<DlgChat>()?.Refresh();
        }
    }
}