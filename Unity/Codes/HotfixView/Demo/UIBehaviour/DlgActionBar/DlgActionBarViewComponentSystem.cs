
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgActionBarViewComponentAwakeSystem : AwakeSystem<DlgActionBarViewComponent> 
	{
		public override void Awake(DlgActionBarViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgActionBarViewComponentDestroySystem : DestroySystem<DlgActionBarViewComponent> 
	{
		public override void Destroy(DlgActionBarViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
