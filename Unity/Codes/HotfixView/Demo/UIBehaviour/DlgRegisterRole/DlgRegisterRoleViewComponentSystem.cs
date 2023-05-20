
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgRegisterRoleViewComponentAwakeSystem : AwakeSystem<DlgRegisterRoleViewComponent> 
	{
		public override void Awake(DlgRegisterRoleViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgRegisterRoleViewComponentDestroySystem : DestroySystem<DlgRegisterRoleViewComponent> 
	{
		public override void Destroy(DlgRegisterRoleViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
