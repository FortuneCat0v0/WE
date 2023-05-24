
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgFormViewComponentAwakeSystem : AwakeSystem<DlgFormViewComponent> 
	{
		public override void Awake(DlgFormViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgFormViewComponentDestroySystem : DestroySystem<DlgFormViewComponent> 
	{
		public override void Destroy(DlgFormViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
