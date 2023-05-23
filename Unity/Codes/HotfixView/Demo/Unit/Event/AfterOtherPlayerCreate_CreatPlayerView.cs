using ET.EventType;
using UnityEngine;

namespace ET
{
    public class AfterOtherPlayerCreate_CreatPlayerView: AEventAsync<EventType.AfterOtherPlayerCreate>
    {
        protected override async ETTask Run(AfterOtherPlayerCreate args)
        {
            await ResourcesComponent.Instance.LoadBundleAsync($"{args.Unit.Config.PrefabName}.unity3d");
            GameObject bundleGameObject =
                    (GameObject)ResourcesComponent.Instance.GetAsset($"{args.Unit.Config.PrefabName}.unity3d", args.Unit.Config.PrefabName);
            GameObject go = UnityEngine.Object.Instantiate(bundleGameObject);
            go.transform.SetParent(GlobalComponent.Instance.Unit, true);
            go.name = "其他玩家";

            args.Unit.AddComponent<GameObjectComponent>().GameObject = go;
            args.Unit.GetComponent<GameObjectComponent>().SpriteRenderer = go.GetComponent<SpriteRenderer>();

            args.Unit.AddComponent<AnimatorComponent>();
            
            args.Unit.AddComponent<OtherPlayerControllerComponent>();

            // TODO 根据关卡配置表，设置初始位置
            args.Unit.Position = args.Unit.Type == UnitType.Player? new Vector3(3f, 5.0f, 0)
                    : new Vector3(1.5f, RandomHelper.RandomNumber(-1, 1), 0);

            await ETTask.CompletedTask;
        }
    }
}