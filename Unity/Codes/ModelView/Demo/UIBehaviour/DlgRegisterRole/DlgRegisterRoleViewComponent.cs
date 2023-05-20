
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgRegisterRoleViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.InputField E_NameInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NameInputField == null )
     			{
		    		this.m_E_NameInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"Sprite_BackGround/E_Name");
     			}
     			return this.m_E_NameInputField;
     		}
     	}

		public UnityEngine.UI.Image E_NameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NameImage == null )
     			{
		    		this.m_E_NameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/E_Name");
     			}
     			return this.m_E_NameImage;
     		}
     	}

		public UnityEngine.UI.Button E_ConfirmButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ConfirmButton == null )
     			{
		    		this.m_E_ConfirmButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/E_Confirm");
     			}
     			return this.m_E_ConfirmButton;
     		}
     	}

		public UnityEngine.UI.Image E_ConfirmImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ConfirmImage == null )
     			{
		    		this.m_E_ConfirmImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/E_Confirm");
     			}
     			return this.m_E_ConfirmImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_NameInputField = null;
			this.m_E_NameImage = null;
			this.m_E_ConfirmButton = null;
			this.m_E_ConfirmImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.InputField m_E_NameInputField = null;
		private UnityEngine.UI.Image m_E_NameImage = null;
		private UnityEngine.UI.Button m_E_ConfirmButton = null;
		private UnityEngine.UI.Image m_E_ConfirmImage = null;
		public Transform uiTransform = null;
	}
}
