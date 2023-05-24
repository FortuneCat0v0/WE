﻿using UnityEngine;

namespace ET
{
    [FriendClass(typeof (PlayerControllerComponent))]
    [FriendClass(typeof (GlobalComponent))]
    [FriendClass(typeof (GameObjectComponent))]
    public class AfterPlayerCreate_CreatePlayerView: AEventAsync<EventType.AfterPlayerCreate>
    {
        protected override async ETTask Run(EventType.AfterPlayerCreate args)
        {
            // Unit View层

            await ResourcesComponent.Instance.LoadBundleAsync($"{args.Unit.Config.PrefabName}.unity3d");
            GameObject bundleGameObject =
                    (GameObject)ResourcesComponent.Instance.GetAsset($"{args.Unit.Config.PrefabName}.unity3d", args.Unit.Config.PrefabName);
            GameObject go = UnityEngine.Object.Instantiate(bundleGameObject);
            go.transform.SetParent(GlobalComponent.Instance.Unit, true);
            go.name = "本地玩家";

            args.Unit.AddComponent<GameObjectComponent>().GameObject = go;
            args.Unit.GetComponent<GameObjectComponent>().SpriteRenderer = go.GetComponent<SpriteRenderer>();

            args.Unit.AddComponent<AnimatorComponent>();

            args.Unit.AddComponent<PlayerControllerComponent>();

            args.Unit.AddComponent<PlayerToHallInteractionComponent, GameObject>(go);

            go.transform.position = Vector3.zero;
            // args.Unit.Position = args.Unit.Type == UnitType.Player? new Vector3(-1.5f, 10.0f, 0)
            //         : new Vector3(1.5f, RandomHelper.RandomNumber(-1, 1), 0);

            await ETTask.CompletedTask;
        }
    }
}