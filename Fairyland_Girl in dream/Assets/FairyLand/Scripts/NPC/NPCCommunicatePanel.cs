using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 任务之间交流的对话框
/// </summary>
public class NPCCommunicatePanel : MonoBehaviour {

    public static NPCCommunicatePanel _instance;
    private TweenScale tween;
    private UILabel label;
    private UIButton btn_getTask;
    private void Awake()
    {
        _instance=this;
        tween = GetComponent<TweenScale>();
        label = transform.Find("Message").GetComponent<UILabel>();
        btn_getTask=transform.Find("btn_getTask").GetComponent<UIButton>();
        btn_getTask.onClick.Add(new EventDelegate(this,"ShowTasks"));
        tween.PlayReverse();
    }
    private bool isHide = false;
    private object oo = new object();
    void Update () {
        
        if (Input.GetKeyDown(KeyCode.Return)) {

            if (!isHide)
            {
                CloseMessage();
            }
        }
	}

    private MissionTaskSystem _currentTask;
    private List<MissionTaskSystem> _tasks;
    /// <summary>
    /// 设置需要显示的文字消息
    /// 与NPC上包含的任务的列表
    /// </summary>
    /// <param name="message">文字消息</param>
    /// <param name="tasks">任务的列表</param>
    public void SetMessage(string message, List<MissionTaskSystem> tasks) {
        // _currentTask =task;
        isHide = false;
        this._tasks = tasks;
        label.text = message;
        tween.PlayForward();
       
       
    }
    /// <summary>
    /// 显示可以领取的任务
    /// </summary>
    void ShowTasks() {
        //调用TaskUI显示NPC的任务列表,当然是还没有被领取的任务
        TaskUI._instance.NpcTasks(_tasks, TaskProgress.NotStart_1);
    }



    public void CloseMessage()
    { 
        tween.PlayReverse();
        isHide = true;

    }
}
