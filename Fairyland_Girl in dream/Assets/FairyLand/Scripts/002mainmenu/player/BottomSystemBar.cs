using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 底部的按钮功能
/// </summary>
public class BottomSystemBar : MonoBehaviour {

    private PlayerInformation playInfo;
    private PlayerPackageSystem packageSystem;

    private UIButton btn_battle;
    private UIButton btn_skill;
    private UIButton btn_Package;
    private UIButton btn_mission;
    private UIButton btn_shop;
    private UIButton btn_system;

    private TweenScale tweenPos;
    private bool isHiden = false;
    private void Awake()
    {
        playInfo = PlayerInformation._instance;
        packageSystem = PlayerPackageSystem._Instance;
        tweenPos = GetComponent<TweenScale>();

        btn_battle = transform.Find("btn-battle").GetComponent<UIButton>();
        btn_Package = transform.Find("btn-package").GetComponent<UIButton>();
        btn_skill = transform.Find("btn-skill").GetComponent<UIButton>();
        btn_mission = transform.Find("btn-mission").GetComponent<UIButton>();
        btn_shop = transform.Find("btn-shop").GetComponent<UIButton>();
        btn_system = transform.Find("btn-system").GetComponent<UIButton>();
        //玩家基础信息的监听
        playInfo.OnPlayInfoChanged += OnPlayInfoChanged;


        EventDelegate packageEvent = new EventDelegate(this, "OpenPackage");
        btn_Package.onClick.Add(packageEvent);

        //查看我的任务（当前玩家已经领取的任务）
        btn_mission.onClick.Add(new EventDelegate(this,"OpenTaskList"));

        btn_battle.onClick.Add(new EventDelegate(this, "OpenBattlePanel"));
        btn_skill.onClick.Add(new EventDelegate(this, "OpenSkillPanel"));
        btn_system.onClick.Add(new EventDelegate(this, "OpenSystemPanel"));

        btn_shop.onClick.Add(new EventDelegate(this, "OpenShopePanel"));
        tweenPos.PlayReverse();
    }

    private void Update()
    {
        //是否显示菜单
        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (!isHiden)
            {
                tweenPos.PlayForward();
                isHiden = true;
            }
            else {
                tweenPos.PlayReverse();
                isHiden = false;
            }
        }
    }

    /// <summary>
    /// 监听玩家的信息
    /// </summary>
    /// <param name="type"></param>
    void OnPlayInfoChanged(PlayerInfoType infoType)
    {
        if (infoType == PlayerInfoType.All || infoType == PlayerInfoType.HeadPortail || infoType == PlayerInfoType.HeadPortail || infoType == PlayerInfoType.Hp || infoType == PlayerInfoType.Level || infoType == PlayerInfoType.Name || infoType == PlayerInfoType.Sp)
        {

        }
    }


    /// <summary>
    /// 战斗面板
    /// </summary>
    void OpenBattlePanel() {

    }
    /// <summary>
    /// 技能面板
    /// </summary>
    void OpenSkillPanel() {
        SkillPanel._instance.OpenSkillPanel();
    }
    /// <summary>
    /// 系统面板
    /// </summary>
    void OpenSystemPanel() {

    }
    /// <summary>
    /// 商店面板
    /// 商店面板比较特殊
    /// 不一样的商人卖的东西是不一样的
    /// </summary>
    void OpenShopePanel() {

    }
    //打开背包
    void OpenPackage() {
        packageSystem.PackageShowOrHidden(true);
    }
    /// <summary>
    /// 打开任务面板
    /// 查看我的任务
    /// （当前玩家已经领取的任务）
    /// </summary>
    void OpenTaskList() {
       
        TaskUI._instance.isShowOrHide(true, PlayerInformation._instance.PlayerID);
    }
}
