using System.Collections.Generic;

namespace ET
{
    public enum RoomState
    {
        Idle,
        Ready,
        Game
    }

    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgForm: Entity, IAwake, IUILogic
    {
        public DlgFormViewComponent View
        {
            get => this.Parent.GetComponent<DlgFormViewComponent>();
        }

        public Dictionary<int, Scroll_Item_form> ScrollItemForms;

        public List<RoomInfo> RoomInfos = new List<RoomInfo>();
        
    }
}