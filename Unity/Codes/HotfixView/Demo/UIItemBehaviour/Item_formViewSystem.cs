
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_formDestroySystem : DestroySystem<Scroll_Item_form> 
	{
		public override void Destroy( Scroll_Item_form self )
		{
			self.DestroyWidget();
		}
	}
}
