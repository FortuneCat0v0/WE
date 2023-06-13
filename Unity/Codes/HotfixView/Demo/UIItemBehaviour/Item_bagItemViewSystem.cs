
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_bagItemDestroySystem : DestroySystem<Scroll_Item_bagItem> 
	{
		public override void Destroy( Scroll_Item_bagItem self )
		{
			self.DestroyWidget();
		}
	}
}
