
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_slotItemDestroySystem : DestroySystem<Scroll_Item_slotItem> 
	{
		public override void Destroy( Scroll_Item_slotItem self )
		{
			self.DestroyWidget();
		}
	}
}
