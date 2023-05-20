using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [FriendClass(typeof (DlgMainMenu))]
    public static class DlgMainMenuSystem
    {
        public static void RegisterUIEvent(this DlgMainMenu self)
        {
            self.View.E_StartGameButton.AddListener(self.OnStartGameClickHandler);
        }

        public static void ShowWindow(this DlgMainMenu self, Entity contextData = null)
        {
        }

        public static void OnStartGameClickHandler(this DlgMainMenu self)
        {
            
        }
    }
}