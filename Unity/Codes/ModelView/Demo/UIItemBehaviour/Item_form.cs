
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class Scroll_Item_form : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_form BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Text E_PatternText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_PatternText == null )
     				{
		    			this.m_E_PatternText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Pattern");
     				}
     				return this.m_E_PatternText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Pattern");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_PlayerNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_PlayerNumText == null )
     				{
		    			this.m_E_PlayerNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_PlayerNum");
     				}
     				return this.m_E_PlayerNumText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_PlayerNum");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_RoomStateText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_RoomStateText == null )
     				{
		    			this.m_E_RoomStateText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_RoomState");
     				}
     				return this.m_E_RoomStateText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_RoomState");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_IntroText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_IntroText == null )
     				{
		    			this.m_E_IntroText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Intro");
     				}
     				return this.m_E_IntroText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Intro");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_JoinButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_JoinButton == null )
     				{
		    			this.m_E_JoinButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Join");
     				}
     				return this.m_E_JoinButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Join");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_JoinImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_JoinImage == null )
     				{
		    			this.m_E_JoinImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Join");
     				}
     				return this.m_E_JoinImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Join");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_PatternText = null;
			this.m_E_PlayerNumText = null;
			this.m_E_RoomStateText = null;
			this.m_E_IntroText = null;
			this.m_E_JoinButton = null;
			this.m_E_JoinImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Text m_E_PatternText = null;
		private UnityEngine.UI.Text m_E_PlayerNumText = null;
		private UnityEngine.UI.Text m_E_RoomStateText = null;
		private UnityEngine.UI.Text m_E_IntroText = null;
		private UnityEngine.UI.Button m_E_JoinButton = null;
		private UnityEngine.UI.Image m_E_JoinImage = null;
		public Transform uiTransform = null;
	}
}
