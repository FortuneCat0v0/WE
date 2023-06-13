
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgBagViewComponentAwakeSystem : AwakeSystem<DlgBagViewComponent> 
	{
		public override void Awake(DlgBagViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgBagViewComponentDestroySystem : DestroySystem<DlgBagViewComponent> 
	{
		public override void Destroy(DlgBagViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
