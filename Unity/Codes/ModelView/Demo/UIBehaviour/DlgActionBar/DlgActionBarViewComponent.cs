
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgActionBarViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_BagButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagButton == null )
     			{
		    		this.m_E_BagButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Panel/E_Bag");
     			}
     			return this.m_E_BagButton;
     		}
     	}

		public UnityEngine.UI.Image E_BagImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagImage == null )
     			{
		    		this.m_E_BagImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Panel/E_Bag");
     			}
     			return this.m_E_BagImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_SlotItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SlotItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_SlotItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Panel/E_SlotItems");
     			}
     			return this.m_E_SlotItemsLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_BagButton = null;
			this.m_E_BagImage = null;
			this.m_E_SlotItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_BagButton = null;
		private UnityEngine.UI.Image m_E_BagImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_SlotItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
