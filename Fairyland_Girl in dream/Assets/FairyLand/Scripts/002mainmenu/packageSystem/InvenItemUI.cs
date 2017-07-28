using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 每个（背包）物品处理自己的事件
/// </summary>
public class InvenItemUI : MonoBehaviour {


    //左边的物品栏
    private  EquipmentPopup _equipPop;
    private Item it;
    private UISprite itemSpirte;
    private UILabel itemLabel;
    private UIButton openPopPanlBtn;
    public UISprite ItemSpirte
    {
        get
        {
            if (itemSpirte == null)
            {
                itemSpirte = transform.Find("item").GetComponent<UISprite>();
            }
            return itemSpirte;
        }

        set
        {
            itemSpirte = value;
        }
    }
    public UILabel ItemLabel
    {
        get
        {
            if (itemLabel == null) {
                itemLabel = transform.Find("numbers").GetComponent<UILabel>();
            }
            return itemLabel;
        }

        set
        {
            itemLabel = value;
        }
    }
    public UIButton OpenPopPanlBtn
    {
        get
        {
            if (openPopPanlBtn == null) {
                openPopPanlBtn=GetComponent<UIButton>();
            }
            return openPopPanlBtn;
        }

        set
        {
            openPopPanlBtn = value;
        }
    }

    private void Awake()
    {
        ItemSpirte = transform.Find("item").GetComponent<UISprite>();
        ItemLabel = transform.Find("numbers").GetComponent<UILabel>();
        openPopPanlBtn = transform.Find("item").GetComponent<UIButton>();
    }

    public void SetInvenItem(Item item) {
        if (item != null) {
            it = item;
            this.ItemLabel.text = item.Count.ToString();
            this.ItemSpirte.spriteName = item.ItemInfo.Icon;
        }
    }


	
	void Start () {
        //添加打开显示的面板
        this.OpenPopPanlBtn.onClick.Add(new EventDelegate(this, "openEuqPanel"));
	}
	
	/// <summary>
    /// 打开panel
    /// </summary>
	void openEuqPanel() {
        if (it.ItemInfo.Itemtype == ItemType.Equip)
        {
            _equipPop = EquipmentPopup._equipPopInstance;
            _equipPop.SetEuqValue(it, true,this.gameObject);
        }
        else if (it.ItemInfo.Itemtype == ItemType.Drug)
        {
            InvenPopupPanel._instance.SetItem(it);
        }
        else if (it.ItemInfo.Itemtype == ItemType.Box) {
            InvenPopupPanel._instance.SetItem(it);
        }
       
    }
}
