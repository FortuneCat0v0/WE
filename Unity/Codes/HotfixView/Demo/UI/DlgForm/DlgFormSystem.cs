using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [FriendClass(typeof (DlgForm))]
    public static class DlgFormSystem
    {
        public static void RegisterUIEvent(this DlgForm self)
        {
            self.RegisterCloseEvent<DlgForm>(self.View.E_CloseButton);
            self.View.E_FormLoopVerticalScrollRect.AddItemRefreshListener(self.OnFormItemLoopHandler);
        }

        public static void ShowWindow(this DlgForm self, Entity contextData = null)
        {
            self.Refresh().Coroutine();
        }

        public static async ETTask Refresh(this DlgForm self)
        {
            M2C_RequestRoomInfos m2CRequestRoomInfos =
                    (M2C_RequestRoomInfos)await self.ZoneScene().GetComponent<SessionComponent>().Session.Call(new C2M_RequestRoomInfos());
            self.RoomInfos.Clear();
            self.RoomInfos.AddRange(m2CRequestRoomInfos.RoomInfos);

            int count = self.RoomInfos.Count;
            self.AddUIScrollItems(ref self.ScrollItemForms, count);
            self.View.E_FormLoopVerticalScrollRect.SetVisible(true, count);
            self.View.E_FormLoopVerticalScrollRect.RefillCellsFromEnd();
        }

        public static void OnFormItemLoopHandler(this DlgForm self, Transform transform, int index)
        {
            Scroll_Item_form scrollItemForm = self.ScrollItemForms[index].BindTrans(transform);
            RoomInfo roomInfo = self.RoomInfos[index];

            scrollItemForm.E_PatternText.text = roomInfo.Pattern;
            scrollItemForm.E_PlayerNumText.text = roomInfo.NowNum.ToString() + '/' + roomInfo.MaxNum.ToString();
            string state = "";
            bool canJoin = false;
            switch ((RoomState)roomInfo.RoomState)
            {
                case RoomState.Idle:
                    state = "等待";
                    canJoin = true;
                    break;
                case RoomState.Game:
                    state = "游戏中";
                    break;
                case RoomState.Ready:
                    state = "准备";
                    canJoin = true;
                    break;
            }

            scrollItemForm.E_RoomStateText.text = state;
            scrollItemForm.E_IntroText.text = roomInfo.Intro;
            scrollItemForm.E_JoinButton.gameObject.SetActive(canJoin);
            if (canJoin)
            {
                scrollItemForm.E_JoinButton.AddListenerAsync(() => { return self.OnJoinRoomHandler(roomInfo.RoomId); });
            }
        }

        public static async ETTask OnJoinRoomHandler(this DlgForm self, long roomId)
        {
            M2C_RequestJoinRoom m2CRequestJoinRoom = null;
            try
            {
                m2CRequestJoinRoom = (M2C_RequestJoinRoom)await self.ZoneScene().GetComponent<SessionComponent>().Session
                        .Call(new C2M_RequestJoinRoom() { RoomId = roomId });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            if (m2CRequestJoinRoom.Error != ErrorCode.ERR_Success)
            {
                Log.Error(m2CRequestJoinRoom.Error.ToString());
            }

            self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Form);
            await ETTask.CompletedTask;
        }
    }
}