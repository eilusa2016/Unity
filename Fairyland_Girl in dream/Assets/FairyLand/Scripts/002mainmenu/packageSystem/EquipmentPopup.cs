using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 点击装备
/// 在另一边显示装备的信息
/// </summary>
public class EquipmentPopup : MonoBehaviour {

    public static EquipmentPopup _equipPopInstance;
    private PlayerInformation playInfo;
    public GameObject euq_starsPrefab;
    private UIButton btn_close_euq;
    private UISprite euqSpirte;
    private UISprite aly_euq;
    private UIGrid grid;
    private UILabel LabelEquName;
    private UILabel LabelQuality;
    private UILabel LabelDamage;
    private UILabel LabelLife;
    private UILabel LabelPower;
    private UILabel LabelDescribe;
    private UILabel LabelLevel;

    private UIButton btnEuqOk;
    private UIButton btnEuqLevelUp;
    private UIButton btnEqupUninstall;
    private Item showItem;
    private GameObject goBj;//目标的对象
    public PlayerInformation PlayInfo
    {
        get
        {
            if (playInfo == null) {
                playInfo = PlayerInformation._instance;
            }
            return playInfo;
        }

        set
        {
            playInfo = value;
        }
    }

    private void Awake()
    {
        _equipPopInstance = this;
         euqSpirte = transform.Find("euqBg/euq").GetComponent<UISprite>();
        //是否已经装备上了
        aly_euq = transform.Find("euqBg/aly-euq").GetComponent<UISprite>();
        grid = transform.Find("euqBg/stars-Scroll-View/Grid").GetComponent<UIGrid>();
        LabelEquName = transform.Find("Label-equName").GetComponent<UILabel>();
        LabelQuality = transform.Find("Label-quality").GetComponent<UILabel>();
        LabelDamage = transform.Find("Label-damage").GetComponent<UILabel>();
        LabelLife = transform.Find("Label-life").GetComponent<UILabel>();
        LabelPower = transform.Find("Label-power").GetComponent<UILabel>();
        LabelDescribe = transform.Find("Label-Describe").GetComponent<UILabel>();
        LabelLevel = transform.Find("Label-Level").GetComponent<UILabel>();


        btnEuqOk = transform.Find("btn-euq-ok").GetComponent<UIButton>();
        btnEuqLevelUp = transform.Find("btn-euq-level").GetComponent<UIButton>();
        btn_close_euq = transform.Find("btn-close-euq").GetComponent<UIButton>();
        btnEqupUninstall = transform.Find("btn-euq-uninstall").GetComponent<UIButton>();


        transform.GetComponent<TweenScale>().PlayReverse();
        btn_close_euq.onClick.Add(new EventDelegate(this, "ClosePopPanel"));
        //点击穿上装备的按你要 
        btnEuqOk.onClick.Add(new EventDelegate(this,"PutThisEqupForPlayer"));
        //升级装备
        btnEuqLevelUp.onClick.Add(new EventDelegate(this, "EqupLevelUp"));
        //卸载装备
        btnEqupUninstall.onClick.Add(new EventDelegate(this, "PutOFFThisEqupForPlayer"));
        PlayInfo = PlayerInformation._instance;
    }
    private void Start()
    {
        //在这里初始化放置一开始为null
        ItemManager._itemInstance.OnItemChange += OnItemChange;
    }
    /// <summary>
    /// 物品属性变化的时候
    /// </summary>
    private void OnItemChange()
    {
        if (this.showItem != null) {

            setItemInformation(showItem);
        }
    }

    /// <summary>
    /// 点击穿上装备
    /// </summary>
    void PutThisEqupForPlayer() {
        if (this.showItem != null) {
            aly_euq.enabled = true;
            this.PlayInfo.PutonEquip(showItem);
            ItemManager._itemInstance.StartItemChanged();
        }
    }
    /// <summary>
    /// 脱下这件装备
    /// </summary>
    void PutOFFThisEqupForPlayer()
    {
        if (this.showItem != null)
        {
            aly_euq.enabled = false;
            this.PlayInfo.PutoffEquip(showItem);
            ItemManager._itemInstance.StartItemChanged();
            btnEqupUninstall.gameObject.SetActive(false);
            btnEuqOk.gameObject.SetActive(true);
            ClosePopPanel();
        }
    }


    /// <summary>
    /// 装备升级
    /// 升级完成后(判断是否已经穿上)
    /// 穿上了的话：先脱下再穿上这件装备就可以了
    /// </summary>
    void EqupLevelUp() {
    // 升级到n级:
    //那么生命 伤害 战斗力 为1 + (n - 1) / 10倍
    //升到level需要消耗的金币
    //Level* price(售价)
        if (this.showItem != null)
        {
            //价格
            float price=showItem.ItemInfo.Price* (showItem.Level+1);
            //钱够的时候才能升级
            if (this.PlayInfo.HaveEnoughMoney(price))
            {
                //付钱
                this.PlayInfo.PayMoney(price);
                //升级前判断是否已经装备上
                bool orIsDress = showItem.Dressed;
                if (showItem.Dressed)
                {
                    //若是已经穿上的装备  需要更新 脱衣  穿衣
                    this.PlayInfo.PutoffEquip(this.showItem);
                }
                //升级
                ItemManager._itemInstance.ItemLevelUp(showItem);
                //因为升级前先脱下了一次  
                //所以保存下原始的状态  如果装备的就要重新装备
                if (orIsDress)
                {
                    this.PlayInfo.PutonEquip(this.showItem);
                    ItemManager._itemInstance.StartItemChanged();
                }
                MessagePanelManager._instance.SetMessage("升级完成", 1f);
            }
            else {
                //钱不够
                MessagePanelManager._instance.SetMessage("升级金额不足",1f);
            }            
        }
    }



    /// <summary>
    /// 设置显示的装备
    /// </summary>
    /// <param name="it"></param>
    /// <param name="isLeft"></param>
    public void SetEuqValue(Item it,bool  isLeft,GameObject go) {
        this.showItem = it;
        this.goBj = go;
        Vector3 pos = transform.localPosition;
        float posX = pos.x;
        if (isLeft)
        {
            posX = -Mathf.Abs(pos.x);
        }
        else
        {
            posX = Mathf.Abs(pos.x);
        }
        transform.localPosition = new Vector3(posX, pos.y, pos.z);

        setItemInformation(it);

        ShowOrClosePanel(true);
    }
    /// <summary>
    /// 设置面板物品属性值
    /// </summary>
    /// <param name="it"></param>
    void setItemInformation(Item it) {

        if (it != null)
        {
            //当前点击打开的物品可能会被出售 
            ItemsScrollViewUI._scrollInstance.setWillSaleItem(it);
            euqSpirte.spriteName = it.ItemInfo.Icon;
            LabelEquName.text = it.ItemInfo.Name;
            LabelLife.text = "生命   " + it.ItemInfo.Hp.ToString();
            LabelPower.text = "战斗力   " + it.ItemInfo.FightPower.ToString();
            LabelQuality.text = "品质   " + it.ItemInfo.QualityLevel.ToString();
            LabelDamage.text = "伤害   " + it.ItemInfo.Damage.ToString();
            LabelDescribe.text = it.ItemInfo.Describe;
            LabelLevel.text = "等级   " + it.Level.ToString();
            aly_euq.enabled = it.Dressed;
            if (it.Dressed)
            {
                btnEqupUninstall.gameObject.SetActive(true);
                btnEuqOk.gameObject.SetActive(false);
            }
            else
            {
                btnEqupUninstall.gameObject.SetActive(false);
                btnEuqOk.gameObject.SetActive(true);

            }
            if (it.ItemInfo.Itemtype != ItemType.Equip)
            {
                btnEuqOk.enabled = false;
                btnEuqLevelUp.enabled = false;
            }
            else
            {
                btnEuqOk.enabled = true;
                btnEuqLevelUp.enabled = true;
            }
        }
        else
        {
            euqSpirte.spriteName = "--";
            LabelEquName.text = "--";
            LabelLife.text = "生命   " + 0;
            LabelPower.text = "战斗力   " + 0;
            LabelQuality.text = "品质   " + 0;
            LabelDamage.text = "伤害   " + 0;
            LabelDescribe.text = "--";
            LabelLevel.text = "--";
            aly_euq.enabled = false;
            btnEuqOk.enabled = false;
            btnEuqLevelUp.enabled = false;
        }
    }



    /// <summary>
    /// 关闭
    /// </summary>
    public void ClosePopPanel() {
        //关闭窗口  可能会被出售的物品也要清空
        ItemsScrollViewUI._scrollInstance.DestoryWillSaleItem();
        ShowOrClosePanel(false);
    }

    public void ShowOrClosePanel(bool isShow) {
        if (isShow)
        {
            transform.GetComponent<TweenScale>().PlayForward();
        }
        else {
            transform.GetComponent<TweenScale>().PlayReverse();
        }

    }
}
