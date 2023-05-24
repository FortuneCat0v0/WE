using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgChat: Entity, IAwake, IUILogic
    {
        public DlgChatViewComponent View
        {
            get => this.Parent.GetComponent<DlgChatViewComponent>();
        }

        public Dictionary<int, Scroll_Item_chat> ScrollItemChats;
    }
}