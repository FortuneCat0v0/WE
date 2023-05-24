using System;

namespace ET
{
    public static class ChatHelper
    {
        public static async ETTask<int> SendMessage(Scene ZoneScene, string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return ErrorCode.ERR_ChatMessageEmpty;
            }

            Chat2C_SendChatInfo chat2CSendChatInfo = null;
            try
            {
                chat2CSendChatInfo = (Chat2C_SendChatInfo)await ZoneScene.GetComponent<SessionComponent>().Session
                        .Call(new C2Chat_SendChatInfo() { ChatMessage = message });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if (chat2CSendChatInfo.Error != ErrorCode.ERR_Success)
            {
                return chat2CSendChatInfo.Error;
            }

            return ErrorCode.ERR_Success;
        }
    }
}