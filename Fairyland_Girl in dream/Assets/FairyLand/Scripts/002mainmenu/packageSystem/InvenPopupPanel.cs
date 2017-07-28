using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 点击左边的装备
/// 这个专门是争对非装备的药品的
/// </summary>
public class InvenPopupPanel : MonoBehaviour {

    public static InvenPopupPanel _instance;
    private TweenScale Inven_Popup;
    private UILabel LabelItemName;
    private UISprite ItemSprite;
    private UILabel LabelItemDes;
    private UIButton btnUseItem;
    private UIButton btnBatchUseItem;
    private UIButton btnClose;
    private Item _showItem;
    private void Awake()
    {
        _instance = this;
        Inven_Popup = transform.Find("Inven-Popup").GetComponent<TweenScale>();
        Inven_Popup.PlayReverse();
        LabelItemName = transform.Find("Inven-Popup/Label-item-name").GetComponent<UILabel>();
        LabelItemDes = transform.Find("Inven-Popup/Label-introduction").GetComponent<UILabel>();
        ItemSprite = transform.Find("Inven-Popup/Item-spire").GetComponent<UISprite>();
        btnUseItem=transform.Find("Inven-Popup/btn-use").GetComponent<UIButton>();
        btnBatchUseItem=transform.Find("Inven-Popup/btn-use-batch").GetComponent<UIButton>();
        btnClose=transform.Find("Inven-Popup/btn-close-pop").GetComponent<UIButton>();
        
        btnClose.onClick.Add(new EventDelegate(this, "CloseInvenPopupPanel"));
        btnUseItem.onClick.Add(new EventDelegate(this, "UseItem"));
        btnBatchUseItem.onClick.Add(new EventDelegate(this, "BatchUseItem"));

    }

    /// <summary>
    /// 使用物品
    /// </summary>
    public void UseItem() {
        if (_showItem != null) {
            PlayerInformation._instance.PlayerUserDrug(this._showItem);
            UseDrugsOrBoxes(_showItem);
           // _showItem.Count--;
            ItemManager._itemInstance.StartItemChanged();
        }
       
    }
    private int barchCounts = 5;
    /// <summary>
    /// 批量使用物品
    /// </summary>
    public void BatchUseItem() {
        if (_showItem != null) {
            int barchCounts2 = _showItem.Count < barchCounts ? _showItem.Count : barchCounts;
            for (int i = 0; i < barchCounts; i++) {
                PlayerInformation._instance.PlayerUserDrug(this._showItem);
                if (!UseDrugsOrBoxes(_showItem)) {
                    break;
                }
                //_showItem.Count--;
            }
            ItemManager._itemInstance.StartItemChanged();
        }

    }
    /// <summary>
    /// 使用药品或者宝箱
    /// </summary>
    /// <param name="it"></param>
    bool UseDrugsOrBoxes(Item it) {
        if (it == null) {
            return false;
        }
        if (it.Count - 1 >= 0) {
            //还有药品才能使用
            it.Count--;
            if (it.Count == 0) {
                //这件药品被用掉了 用掉了就要从持有的背包集合中删除
                //卖掉了也是一样
                ItemManager._itemInstance.RemoveItemList(_showItem);
            }
            return true;
        }
        return false;

    }


    /// <summary>
    /// 设置显示的Item内容  然后显示
    /// </summary>
    /// <param name="item"></param>
    public void SetItem(Item item) {      
        this._showItem = item;
        if (item != null)
        {
            //当前点击打开的物品可能会被出售 
            ItemsScrollViewUI._scrollInstance.setWillSaleItem(item);
            ItemSprite.spriteName = item.ItemInfo.Icon;
            LabelItemName.text = item.ItemInfo.Name;
            LabelItemDes.text = item.ItemInfo.Describe;
        }
        else {
            ItemSprite.spriteName ="bg_道具";
            LabelItemName.text ="--";
            LabelItemDes.text ="--";
        }
        OpenInvenPopPanel();
    }

    /// <summary>
    /// 打开窗口
    /// </summary>
    public void OpenInvenPopPanel() {
        Inven_Popup.PlayForward();
    }
    /// <summary>
    /// 关闭窗口
    /// </summary>
    public void CloseInvenPopupPanel() {
        //关闭窗口  可能会被出售的物品也要清空
        ItemsScrollViewUI._scrollInstance.DestoryWillSaleItem();
        Inven_Popup.PlayReverse();
    }


}
