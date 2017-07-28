using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 背包系统
/// 左边的人物信息面板的控制 全都在这个类中进行
/// 其余背包系统的模块
/// 在各个背包类中进行
/// </summary>
public class PlayerPackageSystem : MonoBehaviour {

    private PlayerInformation playInfo;
    public static PlayerPackageSystem _Instance;
    private TweenPosition tweenPosition;
    private UIButton btn_close_package;
    /***********Left-Role部分*************/
    private Transform Left_Role;
    private UILabel playerName;
    private UISprite HelmSpire;
    private UISprite ClothSpire;
    private UISprite WeaponSprite;
    private UISprite ShoesSprite;
    private UISprite NecklaceSprite;
    private UISprite BraceleSprite;
    private UISprite RingSprite;
    private UISprite WingSprite;

   // private UISprite Hpnumber;
    private UILabel HpLabel;
   //private UISprite damage_number ;
    private UILabel damage_label;
    private UISlider Expnumber;
    private UILabel ExpLabel;
    /***********Left-Role部分end*************/
   
    private void Awake()
    {
        playInfo = PlayerInformation._instance;
        _Instance = this;
        tweenPosition = GetComponent<TweenPosition>();
        btn_close_package=transform.Find("btn-close-package").GetComponent<UIButton>();
        EventDelegate btnClose = new EventDelegate(this, "ClosePageage");
        //关闭工具包的按钮
        btn_close_package.onClick.Add(btnClose);
        /***********Left-Role部分*************/
        #region Left-Role部分
        Left_Role=transform.Find("Left-Role");
        playerName = Left_Role.Find("label-player-name").GetComponent<UILabel>();
        //装备
        HelmSpire=Left_Role.Find("HelmSpire").GetComponent<UISprite>();
        ClothSpire=Left_Role.Find("ClothSpire").GetComponent<UISprite>();
        WeaponSprite=Left_Role.Find("WeaponSprite").GetComponent<UISprite>();
        ShoesSprite=Left_Role.Find("ShoesSprite").GetComponent<UISprite>();
        NecklaceSprite=Left_Role.Find("NecklaceSprite").GetComponent<UISprite>();
        BraceleSprite=Left_Role.Find("BraceleSprite").GetComponent<UISprite>();
        RingSprite = Left_Role.Find("RingSprite").GetComponent<UISprite>();
        WingSprite=Left_Role.Find("WingSprite").GetComponent<UISprite>();
        //数值
       // Hpnumber= Left_Role.Find("life-number").GetComponent<UISprite>();
        HpLabel = Left_Role.Find("life-number/Label").GetComponent<UILabel>();
       // damage_number = Left_Role.Find("damage-number ").GetComponent<UISprite>();
        damage_label = Left_Role.Find("damage-number/Label").GetComponent<UILabel>();
        Expnumber = Left_Role.Find("exp-bg/exp").GetComponent<UISlider>();
        ExpLabel = Left_Role.Find("exp-bg/exp/Label").GetComponent<UILabel>();
        #endregion
        /***********Left-Role部分end*************/
       

        //玩家基础信息的监听
        playInfo.OnPlayInfoChanged += OnPlayInfoChanged;
        playInfo.OnePackage_Left_RoleInfoChange += OnePackage_Left_RoleInfoChange;

    }
    /// <summary>
    /// 人物的装备改变的事件
    /// 装备栏的穿上和脱下
    /// </summary>
    /// <param name="it"></param>
    /// <param name="equChangeType"></param>
    private void OnePackage_Left_RoleInfoChange(Item it, EquChangeType equChangeType)
    {
        if (it == null) {
            GameController.DebugLog("PlayerPackageSystem:OnePackage_Left_RoleInfoChange方法=>it为空", false);
            return;
        }
        UISprite equItem = null;
        equItem = PutOnSwitchPart(it.ItemInfo.EquType, it);
        if (equChangeType == EquChangeType.PutOn)
        {   
            //穿上装备
            if (equItem != null) {
                equItem.GetComponent<RoleEquip>().setItemInfo(it);
            }
        }
        else if (equChangeType == EquChangeType.PutOff) {
            //脱下装备
            //脱下的动作多一点
            //需要更新人物的信息(不过这里只是对于装备栏目的更新所以这个方法里面暂时不写人物的更新)
            string icon = "bg_道具";
            Item its = new Item();
            its.ItemInfo = new ItemInformation();
            its.ItemInfo.Icon = icon;
            //穿上装备
            if (equItem != null)
            {
                equItem.GetComponent<RoleEquip>().setItemInfo(its);
            }
        }
    }


   


    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="infoType"></param>
    private void OnPlayInfoChanged(PlayerInfoType infoType)
    {
        if (infoType == PlayerInfoType.All || infoType == PlayerInfoType.Hp || infoType == PlayerInfoType.Exp || infoType == PlayerInfoType.Damage) {
            InitPlayEquip();
        }
    }

    /// <summary>
    /// 初始化以及给装备赋值
    /// </summary>
    void InitPlayEquip()
    {
        HpLabel.text = playInfo.Hp.ToString();
        damage_label.text = playInfo.Damage.ToString();
        Expnumber.value = (float)playInfo.Exp;
        ExpLabel.text = playInfo.Exp + "/" + playInfo.ExpMax;
        /**
         *下面还要初始化这些装备 
         **/
        OnePackage_Left_RoleInfoChange(playInfo.HelmItem, EquChangeType.PutOn);
        OnePackage_Left_RoleInfoChange(playInfo.ClothItem, EquChangeType.PutOn);
        OnePackage_Left_RoleInfoChange(playInfo.WeaponItem, EquChangeType.PutOn);
        OnePackage_Left_RoleInfoChange(playInfo.ShoesItem, EquChangeType.PutOn);
        OnePackage_Left_RoleInfoChange(playInfo.NecklaceItem, EquChangeType.PutOn);
        OnePackage_Left_RoleInfoChange(playInfo.BraceleItem, EquChangeType.PutOn);
        OnePackage_Left_RoleInfoChange(playInfo.RingItem, EquChangeType.PutOn);
        OnePackage_Left_RoleInfoChange(playInfo.WingItem, EquChangeType.PutOn);
    }



    void ClosePageage() {
        this.PackageShowOrHidden(false);
    }

    /// <summary>
    /// 打开隐藏面板
    /// </summary>
    /// <param name="show"></param>
    public void PackageShowOrHidden(bool show) {
        if (show)
        {
            tweenPosition.PlayForward();
        }
        else {
            tweenPosition.PlayReverse();

        }

    }


    /// <summary>
    /// 选择穿戴在哪个部位上
    /// </summary>
    /// <param name="type">装备类型 装备在那个部位</param>
    /// <param name="it">需要装备或者卸下装备对象</param>
    public UISprite PutOnSwitchPart(EquipType type, Item it)
    {
        UISprite equItem = null;
        switch (type)
        {
            case EquipType.Helm:
                equItem = HelmSpire;
                break;
            case EquipType.Cloth:
                equItem = ClothSpire;
                break;
            case EquipType.Weapon:
                equItem = WeaponSprite;
                break;
            case EquipType.Shoes:
                equItem = ShoesSprite;
                break;
            case EquipType.Necklace:
                equItem = NecklaceSprite;
                break;
            case EquipType.Bracelet:
                equItem = BraceleSprite;
                break;
            case EquipType.Ring:
                equItem = RingSprite;
                break;
            case EquipType.Wing:
                equItem = WingSprite;
                break;

        }
        return equItem;
    }





}
