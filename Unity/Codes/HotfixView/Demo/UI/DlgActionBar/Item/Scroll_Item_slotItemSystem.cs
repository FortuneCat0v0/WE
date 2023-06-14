using UnityEngine;

namespace ET
{
    [FriendClass(typeof (Scroll_Item_slotItem))]
    [FriendClass(typeof (Item))]
    [FriendClass(typeof (BagComponent))]
    public static class Scroll_Item_slotItemSystem
    {
        public static void Refresh(this Scroll_Item_slotItem self, long id, int index)
        {
            // Item item = self.ZoneScene().GetComponent<BagComponent>().GetItemById(id);
            //
            // self.E_IconImage.overrideSprite = IconHelper.LoadIconSprite("Items", item.Config.Icon);
            // self.E_QualityImage.color       = item.ItemQualityColor();
            self.E_HighlightImage.color = new Color(1, 1, 1, 0);
            self.E_SelectButton.AddListenerWithParam<long, int>(self.OnSelectHandler, id, index);
        }

        public static void OnSelectHandler(this Scroll_Item_slotItem self, long Id, int index)
        {
            // Item item = self.ZoneScene().GetComponent<BagComponent>().GetItemById(Id);

            // 高亮
            DlgActionBar dlgActionBar = self.GetParent<DlgActionBar>();
            dlgActionBar.UpdateSlotHightlight(index);
        }

        public static void Highlight(this Scroll_Item_slotItem self, bool on)
        {
            if (on)
            {
                self.E_HighlightImage.color = new Color(1, 1, 1, 1);
            }
            else
            {
                self.E_HighlightImage.color = new Color(1, 1, 1, 0);
            }
        }
    }
}