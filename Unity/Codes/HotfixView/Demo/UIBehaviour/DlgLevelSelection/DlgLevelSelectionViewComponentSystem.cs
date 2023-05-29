
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgLevelSelectionViewComponentAwakeSystem : AwakeSystem<DlgLevelSelectionViewComponent> 
	{
		public override void Awake(DlgLevelSelectionViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgLevelSelectionViewComponentDestroySystem : DestroySystem<DlgLevelSelectionViewComponent> 
	{
		public override void Destroy(DlgLevelSelectionViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
