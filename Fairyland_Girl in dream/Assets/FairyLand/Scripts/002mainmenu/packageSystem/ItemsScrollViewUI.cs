using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 背包系统
/// 物品下拉项目的处理
/// </summary>
public class ItemsScrollViewUI : MonoBehaviour {

    public static ItemsScrollViewUI _scrollInstance;
    private PlayerInformation playInfo;
    private PlayerPackageSystem packageSystem;
    private ItemManager itemManager;
    /**************Right-Role-Inven部分************************/
    private Transform RightRoleInven;
    private UIGrid item_grid;
    private UILabel LabelItemNumbers;
    // private List<Item> ItemList;

    private UIButton btnSale;
    private UIInput inputSaleNumbers;
    private UIButton btnArrangement;

    /**************Right-Role-InvenEND**************************************/
    public GameObject Inven_item;

    public UIGrid Item_grid
    {
        get   
        {
            if (item_grid == null)
            {
                item_grid = RightRoleInven.Find("Item-Scroll-View/item-grid").GetComponent<UIGrid>();
            }
            return item_grid;
        }

        set
        {
            item_grid = value;
        }
    }

    private void Awake()
    {
        _scrollInstance = this;
        playInfo = PlayerInformation._instance;
        packageSystem = PlayerPackageSystem._Instance;
        itemManager = ItemManager._itemInstance;
        /***********Right-Role-Inven****************************/
        RightRoleInven =transform;
        item_grid = RightRoleInven.Find("Item-Scroll-View/item-grid").GetComponent<UIGrid>();
        LabelItemNumbers = RightRoleInven.Find("Label-Item-Numbers").GetComponent<UILabel>();
        btnSale = RightRoleInven.Find("btn-sale").GetComponent<UIButton>();
        btnArrangement = RightRoleInven.Find("btn-arrangement").GetComponent<UIButton>();
        inputSaleNumbers = RightRoleInven.Find("sale-input").GetComponent<UIInput>();
        btnSale.onClick.Add(new EventDelegate(this, "SaleItems"));
        btnArrangement.onClick.Add(new EventDelegate(this, "ArrangementItems"));
        /***********Right-Role-Inven****************************/

        //物品管理器中  更新了物品后  必须广播改变
        itemManager.OnItemChange += OnItemChange;
    }
    /// <summary>
    /// 装备变化的事件
    /// </summary>
    private void OnItemChange()
    {
        UpDateItems();
    }
    /// <summary>
    /// 更新背包内的物品
    /// </summary>
    public void UpDateItems() {
        List<Item> list = itemManager.itemList;
        if (list.Count < 0) { return; }
        GameObject go = null;
        if (Inven_item == null) {
            Debug.LogError("Inven_item预置为空！");
        }
        List<Transform>  children=Item_grid.GetChildList();
        if (children != null) {
            //首先全部清空一次
            for (int i = 0; i < children.Count; i++) {
                NGUITools.Destroy(children[i].gameObject);
                Item_grid.RemoveChild(children[i]); 
            }
        }
        int length = 0;
        foreach (Item item in list)
        {
            //装备上的以及用完的药品是不能显示的
            if (!item.Dressed && item.Count>0) {   
                go = NGUITools.AddChild(Item_grid.gameObject, Inven_item);
                go.GetComponent<InvenItemUI>().SetInvenItem(item);
                length++;
            }
        }
        //告诉表格排序
        Item_grid.AddChild(go.transform);
        
        Item_grid.enabled = true;
        LabelItemNumbers.text = length + "/25";
    }

    private Item _willBeSaleItem;
    /// <summary>
    /// 出售物品
    /// </summary>
    public void SaleItems() {
        string valueStr = inputSaleNumbers.value;
        int number = 0;
        if (valueStr == null || valueStr == "") {
            MessagePanelManager._instance.SetMessage("至少出售一件!", 1f);
            return;
        }
        if (valueStr != null || valueStr != "") {
            number = int.Parse(valueStr);
            if (number < 1) {
                MessagePanelManager._instance.SetMessage("至少出售一件!", 1f);
                return;
            }
            if (_willBeSaleItem == null) {
                MessagePanelManager._instance.SetMessage("选择一件出售的物品!", 1f);
                return;
            }
            if (_willBeSaleItem.Dressed) {
                MessagePanelManager._instance.SetMessage("已经装备的物品无法出售!", 1f);
                return;
            }
            if (number > _willBeSaleItem.Count) {
                MessagePanelManager._instance.SetMessage("该物品的持有数不足!", 1f);
                return;
            }
            float needPrice = number * (_willBeSaleItem.ItemInfo.Price);
            _willBeSaleItem.Count -= number;//卖出
            //收入
            PlayerInformation._instance.IncomeMoney(needPrice);
            //判断是否被移出
            if (_willBeSaleItem.Count <= 0) {
                //买的一件也没有了  那么就要删除
                ItemManager._itemInstance.RemoveItemList(_willBeSaleItem);
            }
        }
        //出售了之后 最好关闭物品介绍的窗口 防止买了后被使用
        EquipmentPopup._equipPopInstance.ClosePopPanel();
        InvenPopupPanel._instance.CloseInvenPopupPanel();
        ItemManager._itemInstance.StartItemChanged();
    }

    /// <summary>
    /// 设置出售物品
    /// </summary>
    /// <param name="ite"></param>
    public void setWillSaleItem(Item ite) {
        _willBeSaleItem = ite;
    }
    /// <summary>
    /// 取消需要出售的物品
    /// </summary>
    public void DestoryWillSaleItem() {
        _willBeSaleItem = null;
    }
    /// <summary>
    /// 整理物品
    /// </summary>
    public void ArrangementItems() {
        UpDateItems();
        OnItemChange();
        MessagePanelManager._instance.SetMessage("系统已经自动整理了!", 1f);

    }
    private void OnDestroy()
    {
        //物品管理器中  更新了物品后  必须广播改变
        itemManager.OnItemChange -= OnItemChange;
    }

}
