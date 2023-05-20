
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgMainMenuViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_StartGameButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartGameButton == null )
     			{
		    		this.m_E_StartGameButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/E_StartGame");
     			}
     			return this.m_E_StartGameButton;
     		}
     	}

		public UnityEngine.UI.Image E_StartGameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartGameImage == null )
     			{
		    		this.m_E_StartGameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/E_StartGame");
     			}
     			return this.m_E_StartGameImage;
     		}
     	}

		public UnityEngine.UI.Button E_SettingButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SettingButton == null )
     			{
		    		this.m_E_SettingButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/E_Setting");
     			}
     			return this.m_E_SettingButton;
     		}
     	}

		public UnityEngine.UI.Image E_SettingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SettingImage == null )
     			{
		    		this.m_E_SettingImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/E_Setting");
     			}
     			return this.m_E_SettingImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_StartGameButton = null;
			this.m_E_StartGameImage = null;
			this.m_E_SettingButton = null;
			this.m_E_SettingImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_StartGameButton = null;
		private UnityEngine.UI.Image m_E_StartGameImage = null;
		private UnityEngine.UI.Button m_E_SettingButton = null;
		private UnityEngine.UI.Image m_E_SettingImage = null;
		public Transform uiTransform = null;
	}
}
