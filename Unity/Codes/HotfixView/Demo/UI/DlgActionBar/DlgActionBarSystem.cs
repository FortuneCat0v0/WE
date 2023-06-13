using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [FriendClass(typeof (DlgActionBar))]
    public static class DlgActionBarSystem
    {
        public static void RegisterUIEvent(this DlgActionBar self)
        {
            self.View.E_BagButton.AddListener(self.OnBagHandler);
        }

        public static void ShowWindow(this DlgActionBar self, Entity contextData = null)
        {
        }

        public static void OnBagHandler(this DlgActionBar self)
        {
            if (!self.isOpenBag)
            {
                self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Bag);
                self.isOpenBag = true;
            }
            else
            {
                self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Bag);
                self.isOpenBag = false;
            }
        }
    }
}