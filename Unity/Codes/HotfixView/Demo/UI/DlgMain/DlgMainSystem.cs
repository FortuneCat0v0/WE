using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [FriendClass(typeof (DlgMain))]
    public static class DlgMainSystem
    {
        public static void RegisterUIEvent(this DlgMain self)
        {
            self.View.E_ChatButton.AddListener(self.OnChatHandler);
        }

        public static void ShowWindow(this DlgMain self, Entity contextData = null)
        {
        }

        public static void OnChatHandler(this DlgMain self)
        {
            self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Chat);
        }
    }
}