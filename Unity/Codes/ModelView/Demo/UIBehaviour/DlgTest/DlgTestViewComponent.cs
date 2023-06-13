
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgTestViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseButton == null )
     			{
		    		this.m_E_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Close");
     			}
     			return this.m_E_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseImage == null )
     			{
		    		this.m_E_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Close");
     			}
     			return this.m_E_CloseImage;
     		}
     	}

		public UnityEngine.UI.InputField E_ItemConfigInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemConfigInputField == null )
     			{
		    		this.m_E_ItemConfigInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"Background/E_ItemConfig");
     			}
     			return this.m_E_ItemConfigInputField;
     		}
     	}

		public UnityEngine.UI.Image E_ItemConfigImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemConfigImage == null )
     			{
		    		this.m_E_ItemConfigImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Background/E_ItemConfig");
     			}
     			return this.m_E_ItemConfigImage;
     		}
     	}

		public UnityEngine.UI.Button E_AddItemButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AddItemButton == null )
     			{
		    		this.m_E_AddItemButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Background/E_AddItem");
     			}
     			return this.m_E_AddItemButton;
     		}
     	}

		public UnityEngine.UI.Image E_AddItemImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AddItemImage == null )
     			{
		    		this.m_E_AddItemImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Background/E_AddItem");
     			}
     			return this.m_E_AddItemImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_CloseButton = null;
			this.m_E_CloseImage = null;
			this.m_E_ItemConfigInputField = null;
			this.m_E_ItemConfigImage = null;
			this.m_E_AddItemButton = null;
			this.m_E_AddItemImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_CloseButton = null;
		private UnityEngine.UI.Image m_E_CloseImage = null;
		private UnityEngine.UI.InputField m_E_ItemConfigInputField = null;
		private UnityEngine.UI.Image m_E_ItemConfigImage = null;
		private UnityEngine.UI.Button m_E_AddItemButton = null;
		private UnityEngine.UI.Image m_E_AddItemImage = null;
		public Transform uiTransform = null;
	}
}
