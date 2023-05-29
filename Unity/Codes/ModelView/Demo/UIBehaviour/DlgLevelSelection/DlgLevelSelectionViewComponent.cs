
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgLevelSelectionViewComponent : Entity,IAwake,IDestroy 
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
		    		this.m_E_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGround/E_Close");
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
		    		this.m_E_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BackGround/E_Close");
     			}
     			return this.m_E_CloseImage;
     		}
     	}

		public UnityEngine.UI.Button E_Level1_1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Level1_1Button == null )
     			{
		    		this.m_E_Level1_1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGround/Levels/E_Level1_1");
     			}
     			return this.m_E_Level1_1Button;
     		}
     	}

		public UnityEngine.UI.Image E_Level1_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Level1_1Image == null )
     			{
		    		this.m_E_Level1_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BackGround/Levels/E_Level1_1");
     			}
     			return this.m_E_Level1_1Image;
     		}
     	}

		public UnityEngine.UI.Button E_HomeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HomeButton == null )
     			{
		    		this.m_E_HomeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGround/Levels/E_Home");
     			}
     			return this.m_E_HomeButton;
     		}
     	}

		public UnityEngine.UI.Image E_HomeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HomeImage == null )
     			{
		    		this.m_E_HomeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BackGround/Levels/E_Home");
     			}
     			return this.m_E_HomeImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_CloseButton = null;
			this.m_E_CloseImage = null;
			this.m_E_Level1_1Button = null;
			this.m_E_Level1_1Image = null;
			this.m_E_HomeButton = null;
			this.m_E_HomeImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_CloseButton = null;
		private UnityEngine.UI.Image m_E_CloseImage = null;
		private UnityEngine.UI.Button m_E_Level1_1Button = null;
		private UnityEngine.UI.Image m_E_Level1_1Image = null;
		private UnityEngine.UI.Button m_E_HomeButton = null;
		private UnityEngine.UI.Image m_E_HomeImage = null;
		public Transform uiTransform = null;
	}
}
