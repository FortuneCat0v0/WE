using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [FriendClass(typeof (RoleInfosComponent))]
    [FriendClass(typeof (DlgRegisterRole))]
    public static class DlgRegisterRoleSystem
    {
        public static void RegisterUIEvent(this DlgRegisterRole self)
        {
            self.View.E_ConfirmButton.AddListenerAsync(() => { return self.OnConfirmClickHandler(); });
        }

        public static void ShowWindow(this DlgRegisterRole self, Entity contextData = null)
        {
        }

        public static async ETTask OnConfirmClickHandler(this DlgRegisterRole self)
        {
            string name = self.View.E_NameInputField.text;

            if (string.IsNullOrEmpty(name))
            {
                Log.Error("Name is null");
                return;
            }

            try
            {
                int errorCode = await LoginHelper.CreateRole(self.ZoneScene(), name);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }

                self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId =
                        self.ZoneScene().GetComponent<RoleInfosComponent>().RoleInfos[0].Id;
                if (self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId == 0)
                {
                    Log.Error("没有选择角色!!!");
                    return;
                }

                errorCode = await LoginHelper.GetRealmKey(self.ZoneScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }

                errorCode = await LoginHelper.EnterGame(self.ZoneScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }
                self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Main);
                self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_RegisterRole);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }
    }
}