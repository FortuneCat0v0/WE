using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [FriendClass(typeof (Scroll_Item_bagItem))]
    [FriendClass(typeof (Item))]
    [FriendClass(typeof (BagComponent))]
    [FriendClass(typeof (DlgBag))]
    public static class DlgBagSystem
    {
        public static void RegisterUIEvent(this DlgBag self)
        {
            self.View.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnLoopItemRefreshHandler);
        }

        public static void ShowWindow(this DlgBag self, Entity contextData = null)
        {
            //打开背包，默认显示武器界面
            // self.View.E_WeaponToggle.IsSelected(true);
            self.OnTopToggleSelectedHandler(0);
        }

        public static void HideWindow(this DlgBag self)
        {
            //回收循环列表项
            self.RemoveUIScrollItems(ref self.ScrollItemBagItems);
        }

        public static void Refresh(this DlgBag self)
        {
            self.RefreshItems();
            self.RefeshPageIndexInfo();
        }

        public static void RefreshItems(this DlgBag self)
        {
            self.ZoneScene().GetComponent<BagComponent>().ItemsMap.TryGetValue((int)self.CurrentItemType, out List<Item> itemList);

            int showCount = itemList == null? 0 : itemList.Count - (self.CurrentPageIndex * 30);
            showCount = showCount > 20? 20 : showCount;
            self.AddUIScrollItems(ref self.ScrollItemBagItems, showCount);
            self.View.E_BagItemsLoopVerticalScrollRect.SetVisible(true, showCount);
        }

        public static void RefeshPageIndexInfo(this DlgBag self)
        {
            int itemCount = self.ZoneScene().GetComponent<BagComponent>().GetItemCountByItemType(self.CurrentItemType);
            int maxShowCount = (self.CurrentPageIndex * 30) + 30;

            // self.View.E_PreviousButton.interactable = self.CurrentPageIndex != 0;
            // self.View.E_NextButton.interactable = itemCount > maxShowCount;
            //
            // int maxPageIndex = Mathf.CeilToInt(itemCount / 30.0f);
            // self.View.E_PageText.text = $"{self.CurrentPageIndex + 1} / {maxPageIndex}";
        }

        public static void OnTopToggleSelectedHandler(this DlgBag self, int index)
        {
            self.CurrentItemType = (ItemType)index;
            self.CurrentPageIndex = 0;
            self.Refresh();
        }

        public static void OnLoopItemRefreshHandler(this DlgBag self, Transform transform, int index)
        {
            self.ZoneScene().GetComponent<BagComponent>().ItemsMap.TryGetValue((int)self.CurrentItemType, out List<Item> itemList);
            Scroll_Item_bagItem scrollItemBagItem = self.ScrollItemBagItems[index].BindTrans(transform);

            index = (self.CurrentPageIndex * 30) + index;
            scrollItemBagItem.Refresh(itemList[index].Id);
        }

        public static void OnNextPageHandler(this DlgBag self)
        {
            ++self.CurrentPageIndex;
            self.Refresh();
        }

        public static void OnPreviousPageHandler(this DlgBag self)
        {
            --self.CurrentPageIndex;
            self.Refresh();
        }
    }
}