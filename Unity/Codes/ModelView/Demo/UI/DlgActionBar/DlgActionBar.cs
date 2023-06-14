using System.Collections.Generic;

namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgActionBar :Entity,IAwake,IUILogic
	{

		public DlgActionBarViewComponent View { get => this.Parent.GetComponent<DlgActionBarViewComponent>();}

		public bool isOpenBag = false;

		public Dictionary<int, Scroll_Item_slotItem> ScrollItemSlotItems;
	}
}
