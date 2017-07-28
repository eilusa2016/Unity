using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 人物信息面板
/// </summary>
public class PlayInfoBar : MonoBehaviour {

    private UISprite playerHead;
    private UILabel playerName;
    private UILabel playLevel;
    private UILabel powerLabel;
    private UISlider expbar;
    private UILabel expLabel;
    private UILabel diamondLabel;
    private UILabel coinsLabel;

    private UILabel hpLabel;
    private UILabel hpRecoverTimeLabel;
    private UILabel hpRecoverTimeLabel_1;

    private UILabel spLabel;
    private UILabel spRecoverTimeLabel;
    private UILabel spRecoverTimeLabel_1;


    private UIButton closeBtn;
    /// <summary>
    /// 玩家信息
    /// </summary>
    private PlayerInformation playerInfo;
    /// <summary>
    /// 人物信息表格的单例对象
    /// </summary>
    public static PlayInfoBar infoBar;
    public TweenPosition tweenPosition;


    //modify-name  Player-modify-name
    private UIButton modifyBtn;
    private TweenScale modifyPanel;
    private UIButton btn_ok;
    private UIButton btn_cancel;
    private UIInput new_name ;

    EventDelegate edele;
    private void Awake()
    {
        infoBar = this;
        playerHead = transform.Find("player-head").GetComponent<UISprite>();
        playerName = transform.Find("Player-label-name").GetComponent<UILabel>();
        playLevel = transform.Find("player-label-lv").GetComponent<UILabel>();
        powerLabel=transform.Find("Player-label-battleforce2").GetComponent<UILabel>();
        expbar = transform.Find("Player-exp-bar/progress-bar").GetComponent<UISlider>();
        expLabel = transform.Find("Player-exp-bar/progress-bar/Label").GetComponent<UILabel>();

        diamondLabel = transform.Find("Player-diamoned/count").GetComponent<UILabel>();
        coinsLabel = transform.Find("Player-money/count").GetComponent<UILabel>();

        hpLabel= transform.Find("left-bottom/Label -hpnum").GetComponent<UILabel>();
        hpRecoverTimeLabel = transform.Find("left-bottom/Label -hpcd").GetComponent<UILabel>();
        hpRecoverTimeLabel_1 = transform.Find("left-bottom/Label -hpcd1").GetComponent<UILabel>();

        spLabel = transform.Find("right-bottom/Label -SPnum").GetComponent<UILabel>();
        spRecoverTimeLabel = transform.Find("right-bottom/Label -SPcd").GetComponent<UILabel>();
        spRecoverTimeLabel_1 = transform.Find("right-bottom/Label -SPcd1").GetComponent<UILabel>();
        closeBtn = transform.Find("Close-Player-InfoBar").GetComponent<UIButton>();
        //位置动画组件
        tweenPosition = transform.GetComponent<TweenPosition>();
        //打开修改名字的弹窗
        modifyBtn = transform.Find("Player-modify-name").GetComponent<UIButton>();
        //弹窗
        modifyPanel = transform.Find("modify-name").GetComponent<TweenScale>();
        btn_ok = modifyPanel.transform.Find("modify-btn-ok").GetComponent<UIButton>();
        btn_cancel = modifyPanel.transform.Find("modify-btn-cancel").GetComponent<UIButton>();
        new_name= modifyPanel.transform.Find("modufy-input-name").GetComponent<UIInput>();

        playerInfo = PlayerInformation._instance;
        PlayerInformation._instance.OnPlayInfoChanged += OnPlayerInfoChanged;

        edele = new EventDelegate(this, "HideInfoPanel");
        closeBtn.onClick.Add(edele) ;
        EventDelegate med = new EventDelegate(this, "openModify");
        med.parameters[0].obj =this;
        modifyBtn.onClick.Add(med);
        //取消修改名字
        btn_cancel.onClick.Add(med);
        //确认修改
        btn_ok.onClick.Add(new EventDelegate(this, "ModifyOK"));


    }
    private bool isOpen = true;

    /// <summary>
    /// 当值发生变化的时候
    /// 会被触发
    /// </summary>
    /// <param name="infoType"></param>
    void OnPlayerInfoChanged(PlayerInfoType infoType)
    {
        //需要更新
        upDateShow();
       
    }
    private void Update()
    {
        UpdateHpAndSpTab();
    }
    /// <summary>
    /// 更新显示
    /// </summary>
    void upDateShow()
    {
        InitBarInfomations();
        UpdateHpAndSpTab();
    }
    /// <summary>
    /// 初始化显示
    /// </summary>
    void InitBarInfomations()
    {

        playerHead.spriteName = playerInfo.HeadPortrail;
        playerName.text = playerInfo.Name;
        playLevel.text = playerInfo.Level.ToString();
        powerLabel.text = playerInfo.Power.ToString();
        expbar.value = playerInfo.Exp/(float.Parse(playerInfo.ExpMax.ToString()));
        expLabel.text = playerInfo.Exp+"/"+ playerInfo.ExpMax;

        diamondLabel.text = playerInfo.Diamond.ToString();
        coinsLabel.text = playerInfo.Coin.ToString();
        //addCoin.onClick += OnAddCoins();
        //addDiamond.onClick += null;
    }
    /// <summary>
    /// 自动恢复的显示
    /// </summary>
    void UpdateHpAndSpTab() {

        #region//这里是计算能量  并非Hp
        // hpLabel.text = playerInfo.Energy + "/" + playerInfo.EnergyMax;
        //if (playerInfo.Energy >= playerInfo.EnergyMax)
        //{
        //    //满格
        //    hpRecoverTimeLabel.text = "能量恢复时间:00:00:00";
        //    hpRecoverTimeLabel_1.text = "能量全部恢复:00:00:00";
        //}
        //else {
        //    int remainTime = playerInfo.recoverCount - (int)playerInfo.energyTimer;
        //    string str = remainTime <= 9 ? "0" + remainTime : remainTime.ToString();
        //    hpRecoverTimeLabel.text = "能量恢复时间:00:00:" + str;
        //    int needCount = 0;
        //    if ((playerInfo.EnergyMax - playerInfo.Energy) % playerInfo.recoverPoint == 0)
        //    {
        //        needCount = (playerInfo.EnergyMax - playerInfo.Energy) / playerInfo.recoverPoint;
        //    }
        //    else {
        //        needCount = (playerInfo.EnergyMax - playerInfo.Energy) / playerInfo.recoverPoint+1;
        //    }
        //    //总秒数
        //    int allSeconds = (needCount) * playerInfo.recoverCount;
        //    //上面已经开始计时了,总秒数也要相应的减去上面少掉的几秒
        //    allSeconds = allSeconds - (playerInfo.recoverCount - remainTime);
        //    //总分钟数
        //    int minu = allSeconds / 60;
        //    //总的小时数
        //    int hours = minu/60;//整数部分是小时
        //    //余下的分数
        //    minu = minu % 60;
        //    //剩下的秒数
        //    int second = allSeconds %60 ;//余下的肯定秒


        //    //需要几小时
        //    string hourstr = hours <=9?"0"+ hours : hours.ToString();
        //    //需要几分
        //    string minutes = minu <= 9?"0" + minu : minu.ToString();
        //    //几秒
        //    string secondStr = second <= 9 ? "0" + second : second.ToString();

        //    hpRecoverTimeLabel_1.text = "能量全部恢复:" + hourstr + ":"+ minutes + ":"+ secondStr;
        //}
        #endregion
        hpLabel.text = playerInfo.Hp + "/" + playerInfo.HpMax;
        if (playerInfo.Hp >= playerInfo.HpMax)
        {
            //满格
            hpRecoverTimeLabel.text = "Hp恢复时间:00:00:00";
            hpRecoverTimeLabel_1.text = "Hp全部恢复:00:00:00";
        }
        else
        {
            int remainTime =Mathf.Abs(playerInfo.recoverCount - (int)playerInfo.hpTimer);
            string str = remainTime <= 9 ? "0" + remainTime : remainTime.ToString();
            hpRecoverTimeLabel.text = "Hp恢复时间:00:00:" + str;
            int needCount = 0;
            //int chazhi = Mathf.Abs(playerInfo.Hp - playerInfo.HpMax);
            int chazhi = playerInfo.HpMax - playerInfo.Hp;
            if ((chazhi) % playerInfo.recoverPoint == 0)
            {
                needCount = chazhi / playerInfo.recoverPoint;
            }
            else
            {
                needCount = chazhi / playerInfo.recoverPoint + 1;
            }
            //总秒数
            int allSeconds = (needCount) * playerInfo.recoverCount;
            //上面已经开始计时了,总秒数也要相应的减去上面少掉的几秒
            allSeconds = allSeconds - (playerInfo.recoverCount - remainTime);
            //总分钟数
            int minu = allSeconds / 60;
            //总的小时数
            int hours = minu / 60;//整数部分是小时
            //余下的分数
            minu = minu % 60;
            //剩下的秒数
            int second = allSeconds % 60;//余下的肯定秒


            //需要几小时
            string hourstr = hours <= 9 ? "0" + hours : hours.ToString();
            //需要几分
            string minutes = minu <= 9 ? "0" + minu : minu.ToString();
            //几秒
            string secondStr = second <= 9 ? "0" + second : second.ToString();

            hpRecoverTimeLabel_1.text = "Hp全部恢复:" + hourstr + ":" + minutes + ":" + secondStr;
        }




        spLabel.text = playerInfo.Toughen + "/" + playerInfo.ToughenMax;
        if (playerInfo.Toughen >= playerInfo.ToughenMax)
        {
            spRecoverTimeLabel.text = "SP恢复时间:00:00:00";
            spRecoverTimeLabel_1.text = "SP全部恢复:00:00:00";
        }
        else {

            int remainTime = Mathf.Abs(playerInfo.recoverCount - (int)playerInfo.toughenTimer);
            string str = remainTime <= 9 ? "0" + remainTime : remainTime.ToString();
            spRecoverTimeLabel.text = "SP恢复时间:00:00:"+str;


            int needCount = 0;
            if (Mathf.Abs((playerInfo.ToughenMax - playerInfo.Toughen)) % playerInfo.recoverPoint == 0)
            {
                needCount = Mathf.Abs((playerInfo.ToughenMax - playerInfo.Toughen)) / playerInfo.recoverPoint;
            }
            else
            {
                needCount = Mathf.Abs((playerInfo.ToughenMax - playerInfo.Toughen)) / playerInfo.recoverPoint + 1;
            }
            //总秒数
            int allSeconds = (needCount) * playerInfo.recoverCount;
            //上面已经开始计时了,总秒数也要相应的减去上面少掉的几秒
            allSeconds = allSeconds - (playerInfo.recoverCount - remainTime);
            //总分钟数
            int minu = allSeconds / 60;
            //总的小时数
            int hours = minu / 60;//整数部分是小时
            //余下的分数
            minu = minu % 60;
            //剩下的秒数
            int second = allSeconds % 60;//余下的肯定秒


            //需要几小时
            string hourstr = hours <= 9 ? "0" + hours : hours.ToString();
            //需要几分
            string minutes = minu <= 9 ? "0" + minu : minu.ToString();
            //几秒
            string secondStr = second <= 9 ? "0" + second : second.ToString();

            spRecoverTimeLabel_1.text = "SP全部恢复:" + hourstr + ":" + minutes + ":" + secondStr;
        }     
    }


    public void ShowInfoPanel() {
        //tweenPosition.gameObject.SetActive(true);
        tweenPosition.PlayForward();
    }
    public void HideInfoPanel()
    {
        tweenPosition.PlayReverse();
        //tweenPosition.gameObject.SetActive(false);
    }

    void openModify(PlayInfoBar p) {
        if (p.isOpen)
        {
            modifyPanel.gameObject.SetActive(true);
            modifyPanel.PlayForward();
            modifyBtn.GetComponent<BoxCollider>().enabled = false;
            p.isOpen = false;
        }
        else {
            modifyPanel.PlayReverse();
            modifyPanel.gameObject.SetActive(false);
            p.isOpen = true;
            modifyBtn.GetComponent<BoxCollider>().enabled = true;
        }
       
    }
    void ModifyOK() {

        if (new_name.value !=null && new_name.value != "") {
            //值被修改了
            //这里注意下  玩家基本信息发生变化 需要广播这个变化
            playerInfo.Name = new_name.value;
            playerInfo.OnPlayerValueChanged(PlayerInfoType.Name);
        }
        modifyBtn.GetComponent<BoxCollider>().enabled = true;
        modifyPanel.PlayReverse();
        this.isOpen = true;
        modifyPanel.gameObject.SetActive(false);
       
    }


    private void OnDestroy()
    {
        //取消注册
        PlayerInformation._instance.OnPlayInfoChanged -= OnPlayerInfoChanged;
    }
}
