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
            self.View.E_FormButton.AddListener(self.OnFormHandler);
            self.View.E_LevelButton.AddListener(self.OnLevelHandler);
            self.View.E_TestButton.AddListener(self.OnTestHandler);
        }

        public static void ShowWindow(this DlgMain self, Entity contextData = null)
        {
        }

        public static void OnChatHandler(this DlgMain self)
        {
            self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Chat);
        }

        public static void OnFormHandler(this DlgMain self)
        {
            self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Form);
        }

        public static void OnLevelHandler(this DlgMain self)
        {
            self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_LevelSelection);
        }
        public static void OnTestHandler(this DlgMain self)
        {
            self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Test);
        }
    }
}