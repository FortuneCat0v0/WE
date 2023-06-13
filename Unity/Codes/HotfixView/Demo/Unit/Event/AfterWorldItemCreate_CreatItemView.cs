using ET.EventType;
using UnityEngine;

namespace ET
{
    public class AfterWorldItemCreate_CreatItemView: AEventAsync<AfterWorldItemCreate>
    {
        protected override async ETTask Run(AfterWorldItemCreate args)
        {
            await ResourcesComponent.Instance.LoadBundleAsync($"{args.Unit.Config.PrefabName}.unity3d");
            GameObject bundleGameObject =
                    (GameObject)ResourcesComponent.Instance.GetAsset($"{args.Unit.Config.PrefabName}.unity3d", args.Unit.Config.PrefabName);
            GameObject go = UnityEngine.Object.Instantiate(bundleGameObject);
            go.transform.SetParent(GlobalComponent.Instance.Unit, true);
            // go.name = "本地玩家";
            
            // 设置Id
            go.GetComponent<UnitId>().id = args.Unit.Id;

            args.Unit.AddComponent<GameObjectComponent>().GameObject = go;
            // TODO 设置图片
            args.Unit.GetComponent<GameObjectComponent>().SpriteRenderer =
                    (go.GetComponent<ReferenceCollector>().GetObject("Sprite") as GameObject).GetComponent<SpriteRenderer>();
            // 修改碰撞体尺寸
            Sprite sprite = args.Unit.GetComponent<GameObjectComponent>().SpriteRenderer.sprite;
            Vector2 newSize = new Vector2(sprite.bounds.size.x, sprite.bounds.size.y);
            BoxCollider2D boxCollider2D = go.GetComponent<BoxCollider2D>();
            boxCollider2D.size = newSize;
            boxCollider2D.offset = new Vector2(0, sprite.bounds.center.y);
        }
    }
}