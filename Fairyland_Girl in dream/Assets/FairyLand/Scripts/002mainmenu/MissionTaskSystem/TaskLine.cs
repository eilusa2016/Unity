using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 每一个任务显示条的脚本控件
/// </summary>
public class TaskLine : MonoBehaviour {



    private UISprite taskIcon;
    private UILabel taskNameLabel;
    private UILabel tranScriptNameLabel;
    private UILabel rewardCoinNumberLabel;
    private UILabel rewardDiamonedNumberLabel;
    private UILabel rewardEXPNumberLabel;
    private UIButton btn_getRewards;
    private UIButton btn_intoTranScripts;


    private void Awake()
    {
       
        taskIcon = transform.Find("TaskIconSprite").GetComponent<UISprite>();
        taskNameLabel = transform.Find("TaskNameLabel").GetComponent<UILabel>();
        tranScriptNameLabel = transform.Find("TaskNameLabel").GetComponent<UILabel>();
        rewardCoinNumberLabel = transform.Find("RewardCoinNumberLabel").GetComponent<UILabel>();
        rewardDiamonedNumberLabel = transform.Find("RewardDIamonedNumberLabel").GetComponent<UILabel>();
        rewardEXPNumberLabel = transform.Find("RewardEXPNumberLabel (1)").GetComponent<UILabel>();
        btn_getRewards = transform.Find("btn_getRewards").GetComponent<UIButton>();
        btn_intoTranScripts = transform.Find("btn_ intoTranScripts").GetComponent<UIButton>();


        
        btn_getRewards.onClick.Add(new EventDelegate(this, "GetRewards"));
        btn_getRewards.gameObject.SetActive(false);
        //进入
        btn_intoTranScripts.onClick.Add(new EventDelegate(this, "IntoTransScript"));

    }

    private MissionTaskSystem _task;
    /// <summary>
    /// 设置任务属性
    /// </summary>
    /// <param name="task"></param>
    public void SetTask(MissionTaskSystem task) {
        this._task = task;
        taskIcon.spriteName = task.TaskIcon;
        taskNameLabel.text = task.TaskName;
        tranScriptNameLabel.text = task.TaskTranscriptId.ToString();
        rewardCoinNumberLabel.text ="0";
        rewardDiamonedNumberLabel.text = "0";
        rewardEXPNumberLabel.text = "0";
        UILabel label = btn_intoTranScripts.transform.GetComponentInChildren<UILabel>();
        if (_task.TaskProgress == TaskProgress.NotStart_1)
        {
            label.text = "领取任务";
        }
        else if (_task.TaskProgress == TaskProgress.AcceptTask_2)
        {
            label.text = "领取未完成";
        }
        else if (_task.TaskProgress == TaskProgress.CompleteTask_3)
        {
            btn_getRewards.gameObject.SetActive(true);
            btn_intoTranScripts.gameObject.SetActive(false);
            //领取奖励
        }

    }

    /// <summary>
    /// 领取任务
    /// </summary>
    void IntoTransScript() {
        //由玩家来领取这个任务
        UILabel label = btn_intoTranScripts.transform.GetComponentInChildren<UILabel>();
        if (label.text == "领取任务") {
            PlayerInformation._instance.GetThisTask(_task);
        }
        if (_task.TaskProgress == TaskProgress.AcceptTask_2)
        {
            label.text = "领取未完成";
        }
        else if (_task.TaskProgress == TaskProgress.CompleteTask_3)
        {
            btn_getRewards.gameObject.SetActive(true);
            btn_intoTranScripts.gameObject.SetActive(false);
            //领取奖励
        }
    }
    /// <summary>
    /// 获得奖励
    /// </summary>
    void GetRewards() {

    }
}
