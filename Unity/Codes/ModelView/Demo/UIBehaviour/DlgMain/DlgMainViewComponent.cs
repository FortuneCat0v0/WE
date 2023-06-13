
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgMainViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_ChatButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChatButton == null )
     			{
		    		this.m_E_ChatButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Chat");
     			}
     			return this.m_E_ChatButton;
     		}
     	}

		public UnityEngine.UI.Image E_ChatImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChatImage == null )
     			{
		    		this.m_E_ChatImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Chat");
     			}
     			return this.m_E_ChatImage;
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
		    		this.m_E_SettingButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Setting");
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
		    		this.m_E_SettingImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Setting");
     			}
     			return this.m_E_SettingImage;
     		}
     	}

		public UnityEngine.UI.Button E_FormButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FormButton == null )
     			{
		    		this.m_E_FormButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Form");
     			}
     			return this.m_E_FormButton;
     		}
     	}

		public UnityEngine.UI.Image E_FormImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FormImage == null )
     			{
		    		this.m_E_FormImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Form");
     			}
     			return this.m_E_FormImage;
     		}
     	}

		public UnityEngine.UI.Button E_LevelButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LevelButton == null )
     			{
		    		this.m_E_LevelButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Level");
     			}
     			return this.m_E_LevelButton;
     		}
     	}

		public UnityEngine.UI.Image E_LevelImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LevelImage == null )
     			{
		    		this.m_E_LevelImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Level");
     			}
     			return this.m_E_LevelImage;
     		}
     	}

		public UnityEngine.UI.Button E_TestButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TestButton == null )
     			{
		    		this.m_E_TestButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Test");
     			}
     			return this.m_E_TestButton;
     		}
     	}

		public UnityEngine.UI.Image E_TestImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TestImage == null )
     			{
		    		this.m_E_TestImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Test");
     			}
     			return this.m_E_TestImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ChatButton = null;
			this.m_E_ChatImage = null;
			this.m_E_SettingButton = null;
			this.m_E_SettingImage = null;
			this.m_E_FormButton = null;
			this.m_E_FormImage = null;
			this.m_E_LevelButton = null;
			this.m_E_LevelImage = null;
			this.m_E_TestButton = null;
			this.m_E_TestImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ChatButton = null;
		private UnityEngine.UI.Image m_E_ChatImage = null;
		private UnityEngine.UI.Button m_E_SettingButton = null;
		private UnityEngine.UI.Image m_E_SettingImage = null;
		private UnityEngine.UI.Button m_E_FormButton = null;
		private UnityEngine.UI.Image m_E_FormImage = null;
		private UnityEngine.UI.Button m_E_LevelButton = null;
		private UnityEngine.UI.Image m_E_LevelImage = null;
		private UnityEngine.UI.Button m_E_TestButton = null;
		private UnityEngine.UI.Image m_E_TestImage = null;
		public Transform uiTransform = null;
	}
}
