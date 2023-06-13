using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [FriendClass(typeof (DlgTest))]
    public static class DlgTestSystem
    {
        public static void RegisterUIEvent(this DlgTest self)
        {
            self.RegisterCloseEvent<DlgTest>(self.View.E_CloseButton);
            self.View.E_AddItemButton.AddListener(self.OnAddItemHandler);
        }

        public static void ShowWindow(this DlgTest self, Entity contextData = null)
        {
        }

        public static void OnAddItemHandler(this DlgTest self)
        {
            string itemConfig = self.View.E_ItemConfigInputField.text;

            self.ZoneScene().GetComponent<SessionComponent>().Session.Send(new C2M_TestAddItem() { ItemConfig = int.Parse(itemConfig) });
        }
    }
}