
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_chatDestroySystem : DestroySystem<Scroll_Item_chat> 
	{
		public override void Destroy( Scroll_Item_chat self )
		{
			self.DestroyWidget();
		}
	}
}
