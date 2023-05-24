using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ET
{
    [FriendClass(typeof (RoleInfosComponent))]
    [FriendClass(typeof (ServerInfosComponent))]
    public static class DlgLoginSystem
    {
        public static void RegisterUIEvent(this DlgLogin self)
        {
            self.View.E_LoginButton.AddListenerAsync(self.OnLoginClickHandler);
        }

        public static void ShowWindow(this DlgLogin self, Entity contextData = null)
        {
            self.View.E_AccountInputField.text = PlayerPrefs.GetString("Account", string.Empty);
            self.View.E_PasswordInputField.text = PlayerPrefs.GetString("Password", string.Empty);
        }

        public static async ETTask OnLoginClickHandler(this DlgLogin self)
        {
            try
            {
                string account = self.View.E_AccountInputField.text;
                string password = self.View.E_PasswordInputField.text;

                int errorCode = await LoginHelper.Login(self.DomainScene(), ConstValue.LoginAddress, account, password);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }

                errorCode = await LoginHelper.GetServerInfos(self.ZoneScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }

                self.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Login);
                PlayerPrefs.SetString("Account", account);
                PlayerPrefs.SetString("Password", password);

                // 默认选第一个区服
                self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId =
                        int.Parse(self.ZoneScene().GetComponent<ServerInfosComponent>().ServerInfoList[0].Id.ToString());

                // 获取角色
                errorCode = await LoginHelper.GetRoles(self.ZoneScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }

                // 判断角色是否创建了
                if (self.ZoneScene().GetComponent<RoleInfosComponent>().RoleInfos.Count > 0)
                {
                    self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId =
                            self.ZoneScene().GetComponent<RoleInfosComponent>().RoleInfos[0].Id;

                    if (self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId == 0)
                    {
                        Log.Error("未选择角色!!!");
                        return;
                    }

                    // 准备进入游戏
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
                }
                else
                {
                    // 不存在则要求新创建一个
                    self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_RegisterRole);
                }

                self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Login);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }

        public static void HideWindow(this DlgLogin self)
        {
        }
    }
}