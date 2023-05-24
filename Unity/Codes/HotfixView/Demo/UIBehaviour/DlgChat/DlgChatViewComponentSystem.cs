
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgChatViewComponentAwakeSystem : AwakeSystem<DlgChatViewComponent> 
	{
		public override void Awake(DlgChatViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgChatViewComponentDestroySystem : DestroySystem<DlgChatViewComponent> 
	{
		public override void Destroy(DlgChatViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
