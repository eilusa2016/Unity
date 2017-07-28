using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏控制面板UI
/// 左上角的控件 人物头像
/// 每个控件  都是一个模块
/// </summary>
public class PlayHeadBar : MonoBehaviour {

    //头像
    private UISprite headSprite;
    private UILabel playerLabelName;
    private UILabel playerLabelLv;
    private UISlider playerHp;
    private UILabel labelHpBar;
    private UISlider playerSp;
    private UILabel labelSpBar;
    private UIButton btnAddHp;
    private UIButton btnAddSp;
    private PlayerInformation playerInfo;
    public PlayInfoBar playInfoBar;

    private UIButton headSpriteBtn;

    /// <summary>
    /// 初始化组件对象
    /// </summary>
    private void Awake()
    {
        headSprite = transform.Find("player-head").GetComponent<UISprite>();
        headSpriteBtn = headSprite.transform.GetComponent<UIButton>();

        playerLabelName = transform.Find("player-label-name").GetComponent<UILabel>();
        playerLabelLv = transform.Find("player-label-lv").GetComponent<UILabel>();
        playerHp = transform.Find("player-hp-bloodbar").GetComponent<UISlider>();
        labelHpBar=transform.Find("player-hp-bloodbar/label-hpbar").GetComponent<UILabel>();

        playerSp = transform.Find("player-sp-spbar").GetComponent<UISlider>();
        labelSpBar =transform.Find("player-sp-spbar/label-sppbar").GetComponent<UILabel>();

        btnAddHp = transform.Find("player-btn-addhp").GetComponent<UIButton>();
        btnAddSp = transform.Find("player-btn-addmp").GetComponent<UIButton>();

        playerInfo = PlayerInformation._instance;
       
        //注册事件   这里需要  PlayerInformation比这个类先执行  这样  info的awake方法比他的先执行，那么这里才可以获取实例
        //当然  也可以在start中写  但是 PlayerInformation比这个类先执行  在edit/scpript Execution Order中设置
        PlayerInformation._instance.OnPlayInfoChanged += OnPlayerInfoChanged;


        //头像的点击事件委托
        EventDelegate eventD = new EventDelegate(this, "OnSpireHeadClick");
        //为事件添加委托
        headSpriteBtn.onClick.Add(eventD);

    }
    /// <summary>
    /// 头像被点击
    /// </summary>
    public void OnSpireHeadClick() {
        playInfoBar = PlayInfoBar.infoBar;
        playInfoBar.ShowInfoPanel();
    }

    /// <summary>
    /// 当值发生变化的时候
    /// 会被触发
    /// </summary>
    /// <param name="infoType"></param>
    void OnPlayerInfoChanged(PlayerInfoType infoType) {
        if (infoType == PlayerInfoType.All || infoType == PlayerInfoType.HeadPortail || infoType == PlayerInfoType.Hp || infoType == PlayerInfoType.Level || infoType == PlayerInfoType.Name || infoType == PlayerInfoType.Sp|| infoType == PlayerInfoType.Energy) {

            //需要更新
            upDateShow();
        }

    }
    /// <summary>
    /// 更新显示
    /// </summary>
    void upDateShow() {
        InitBarInfomations();
    }
    /// <summary>
    /// 初始化显示
    /// </summary>
    void InitBarInfomations()
    {
        headSprite.spriteName = playerInfo.HeadPortrail;
        playerLabelName.text = playerInfo.Name;
        playerLabelLv.text = "Lv." + playerInfo.Level;
        //playerHp.value = playerInfo.Energy/(float.Parse(playerInfo.EnergyMax+""));
        //labelHpBar.text = playerInfo.Energy + "/" + playerInfo.EnergyMax;

        playerHp.value = playerInfo.Hp / (float.Parse(playerInfo.HpMax + ""));
        labelHpBar.text = playerInfo.Hp + "/" + playerInfo.HpMax;

        playerSp.value = playerInfo.Toughen/ (float.Parse(playerInfo.ToughenMax+""));
        labelSpBar.text = playerInfo.Toughen + "/" + playerInfo.ToughenMax;

        //btnAddHp.onClick += null;
        //btnAddSp.onClick += null;


    }
    private void OnDestroy()
    {
        //取消注册
        PlayerInformation._instance.OnPlayInfoChanged -= OnPlayerInfoChanged;
    }
}
