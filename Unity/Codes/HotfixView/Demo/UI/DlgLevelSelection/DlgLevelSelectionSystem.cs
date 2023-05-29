using System.Collections;
using System.Collections.Generic;
using System;
using CommandLine;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [FriendClass(typeof (DlgLevelSelection))]
    public static class DlgLevelSelectionSystem
    {
        public static void RegisterUIEvent(this DlgLevelSelection self)
        {
            self.RegisterCloseEvent<DlgLevelSelection>(self.View.E_CloseButton);
            self.View.E_Level1_1Button.AddListenerAsync(() => { return self.OnLevelSelectionHandler("Level1_1"); });
            self.View.E_HomeButton.AddListenerAsync(() => { return self.OnLevelSelectionHandler("Home"); });
        }

        public static void ShowWindow(this DlgLevelSelection self, Entity contextData = null)
        {
        }

        public static async ETTask OnLevelSelectionHandler(this DlgLevelSelection self, string levelName)
        {
            M2C_RequestTransferLevel m2CRequestTransferLevel = null;
            try
            {
                m2CRequestTransferLevel = (M2C_RequestTransferLevel)await self.ZoneScene().GetComponent<SessionComponent>().Session
                        .Call(new C2M_RequestTransferLevel() { LevelName = levelName });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            if (m2CRequestTransferLevel.Error != ErrorCode.ERR_Success)
            {
                Log.Error(m2CRequestTransferLevel.Error.ToString());
            }
            
            await ETTask.CompletedTask;
        }
    }
}