using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 背包系统
/// 左边的人物面板
/// </summary>
public class PackageLeftRoleUI : MonoBehaviour {


    private PlayerInformation playInfo;
    private static PackageLeftRoleUI _Instance;
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

        /***********Left-Role部分*************/
        #region Left-Role部分
        Left_Role = transform;
        playerName = Left_Role.Find("label-player-name").GetComponent<UILabel>();
        //装备
        HelmSpire = Left_Role.Find("HelmSpire").GetComponent<UISprite>();
        ClothSpire = Left_Role.Find("ClothSpire").GetComponent<UISprite>();
        WeaponSprite = Left_Role.Find("WeaponSprite").GetComponent<UISprite>();
        ShoesSprite = Left_Role.Find("ShoesSprite").GetComponent<UISprite>();
        NecklaceSprite = Left_Role.Find("NecklaceSprite").GetComponent<UISprite>();
        BraceleSprite = Left_Role.Find("BraceleSprite").GetComponent<UISprite>();
        RingSprite = Left_Role.Find("RingSprite").GetComponent<UISprite>();
        WingSprite = Left_Role.Find("WingSprite").GetComponent<UISprite>();
        //数值
        // Hpnumber= Left_Role.Find("life-number").GetComponent<UISprite>();
        HpLabel = Left_Role.Find("life-number/Label").GetComponent<UILabel>();
        // damage_number = Left_Role.Find("damage-number ").GetComponent<UISprite>();
        damage_label = Left_Role.Find("damage-number/Label").GetComponent<UILabel>();
        Expnumber = Left_Role.Find("exp-bg/exp").GetComponent<UISlider>();
        ExpLabel = Left_Role.Find("exp-bg/exp/Label").GetComponent<UILabel>();
        #endregion
        /***********Left-Role部分end*************/
    }
}
