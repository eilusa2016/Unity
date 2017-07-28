using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 任务面板  (已经装备上的装备栏目)
///每个装备位上对应的装备
/// </summary>
public class RoleEquip : MonoBehaviour {

    private int _id;
    private Item it;
    private UISprite itemSprite;
    private UIButton itemBtn;

    public UIButton ItemBtn
    {
        get
        {
            if (itemBtn == null) {
                itemBtn = GetComponent<UIButton>();
            }
            return itemBtn;
        }

        set
        {
            itemBtn = value;
        }
    }

    private void Awake()
    {
        itemSprite = GetComponent<UISprite>();
        itemBtn = GetComponent<UIButton>();
    }


    // Use this for initialization
    void Start()
    {
        this.ItemBtn.onClick.Add(new EventDelegate(this, "openEuqPanel"));
    }
    //左边的物品栏
    private EquipmentPopup _equipPop;
    /// <summary>
    /// 打开panel
    /// </summary>
    void openEuqPanel()
    {
        _equipPop = EquipmentPopup._equipPopInstance;
        _equipPop.SetEuqValue(it,false,null);
    }


    public void setItemInfoId(int id) {
        this._id=id;
        if (itemSprite == null) {
            itemSprite = GetComponent<UISprite>();
        }
        ItemInformation itemInfo = null;
        ItemManager._itemInstance.itemInfoDic.TryGetValue(id, out itemInfo);

        try
        {
            this.it = ItemManager._itemInstance.itemList.Find(v1 => v1.ItemInfo.Id == id);
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Message.ToString());
           
        }
        if (itemInfo != null) {
            itemSprite.spriteName = itemInfo.Icon;
            UIButton btn = itemSprite.transform.GetComponent<UIButton>();
            if (btn != null)
            {
                btn.hoverSprite = it.ItemInfo.Icon;
                btn.pressedSprite = it.ItemInfo.Icon;
                btn.disabledSprite = it.ItemInfo.Icon;
            }
        }
    }
    /// <summary>
    /// 更新装备的显示
    /// </summary>
    /// <param name="it"></param>
    public void setItemInfo(Item it)
    {
        this.it = it;
        if (itemSprite == null)
        {
            itemSprite = GetComponent<UISprite>();
        }
        if (it != null)
        {
            itemSprite.spriteName = it.ItemInfo.Icon;
            UIButton btn=itemSprite.transform.GetComponent<UIButton>();
            if (btn != null) {
                btn.normalSprite = it.ItemInfo.Icon;
                btn.hoverSprite = it.ItemInfo.Icon;
                btn.pressedSprite = it.ItemInfo.Icon;
                btn.disabledSprite = it.ItemInfo.Icon;
            }
        }
    }
}
