﻿using System;

namespace ET
{
    public class G2Chat_RequestExitChatHandler: AMActorRpcHandler<ChatInfoUnit, G2Chat_RequestExitChat, Chat2G_RequestExitChat>
    {
        protected override async ETTask Run(ChatInfoUnit unit, G2Chat_RequestExitChat request, Chat2G_RequestExitChat response, Action reply)
        {
            ChatInfoUnitsComponent chatInfoUnitsComponent = unit.DomainScene().GetComponent<ChatInfoUnitsComponent>();

            chatInfoUnitsComponent.Remove(unit.Id);

            reply();

            await ETTask.CompletedTask;
        }
    }
}