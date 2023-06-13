
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgItemPopUpViewComponentAwakeSystem : AwakeSystem<DlgItemPopUpViewComponent> 
	{
		public override void Awake(DlgItemPopUpViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgItemPopUpViewComponentDestroySystem : DestroySystem<DlgItemPopUpViewComponent> 
	{
		public override void Destroy(DlgItemPopUpViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
