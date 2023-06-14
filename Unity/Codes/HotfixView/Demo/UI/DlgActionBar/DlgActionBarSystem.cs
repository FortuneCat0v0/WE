using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [FriendClass(typeof (DlgActionBar))]
    public static class DlgActionBarSystem
    {
        public static void RegisterUIEvent(this DlgActionBar self)
        {
            self.View.E_BagButton.AddListener(self.OnBagHandler);
            self.View.E_SlotItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnLoopItemRefreshHandler);
        }

        public static void ShowWindow(this DlgActionBar self, Entity contextData = null)
        {
            self.Refresh();
        }

        public static void Refresh(this DlgActionBar self)
        {
            self.AddUIScrollItems(ref self.ScrollItemSlotItems, 7);
            self.View.E_SlotItemsLoopVerticalScrollRect.SetVisible(true, 7);
        }

        public static void OnBagHandler(this DlgActionBar self)
        {
            if (!self.isOpenBag)
            {
                self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Bag);
                self.isOpenBag = true;
            }
            else
            {
                self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Bag);
                self.isOpenBag = false;
            }
        }

        public static void OnLoopItemRefreshHandler(this DlgActionBar self, Transform transform, int index)
        {
            // self.ZoneScene().GetComponent<BagComponent>().ItemsMap.TryGetValue((int)self.CurrentItemType, out List<Item> itemList);
            Scroll_Item_slotItem scrollItemBagItem = self.ScrollItemSlotItems[index].BindTrans(transform);

            // index = (self.CurrentPageIndex * 30) + index;
            scrollItemBagItem.Refresh(0, index);
        }

        /// <summary>
        /// 更新选择高亮
        /// </summary>
        /// <param name="self"></param>
        /// <param name="index"></param>
        public static void UpdateSlotHightlight(this DlgActionBar self, int index)
        {
            foreach (var slot in self.ScrollItemSlotItems)
            {
                if (slot.Key == index)
                {
                    slot.Value.Highlight(true);
                }
                else
                {
                    slot.Value.Highlight(false);
                }
            }
        }
    }
}