using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 任务列表UI的控制
/// 这个UI是点击出现用户所包含的任务的列表
/// </summary>
public class TaskUI : MonoBehaviour {

    public static TaskUI _instance;

    private UIGrid tasksList;
    public GameObject TaskLine;//预置物体
    private TweenPosition taskParentPanel;
    private UIButton btn_close;

    private void Awake()
    {
        _instance = this;
        taskParentPanel = transform.parent.GetComponent<TweenPosition>();
        tasksList = transform.Find("Task-Scroll-View/Grid").GetComponent<UIGrid>();
        btn_close = transform.Find("CloseBtn").GetComponent<UIButton>();
        btn_close.onClick.Add(new EventDelegate(this,"CloseTaskPanel"));
    }
    private void Start()
    {
        TaskManager._instance.OnTaskListChanged += OnTaskListChanged;
    }
    /// <summary>
    /// 初始化需要做的任务
    /// 每次打开任务面板
    /// </summary>
    void InitTasks() {
        List<MissionTaskSystem> list = TaskManager._instance.getTasksByProgress(TaskProgress.AcceptTask_2);
        UpdateAndSetTasks(list, TaskProgress.AcceptTask_2);
    }
    /// <summary>
    /// 任务列表发生更新
    /// （这个刷新任务列表只在系统随机的增加了任务才会触发）
    /// </summary>
    /// <param name="taskType"></param>
    private void OnTaskListChanged(TaskProgress progress)
    {

       // UpdateTasks(progress);
    }


    /// <summary>
    /// 和NPC对话是打开查看可以领取的任务
    /// </summary>
    /// <param name="tasks"></param>
    /// <param name="progress"></param>
    public void NpcTasks(List<MissionTaskSystem> tasks, TaskProgress progress) {
        UpdateAndSetTasks(tasks, progress);
        NpcOpenTaskPanel();
    }


    /// <summary>
    /// 设置消息
    /// </summary>
    /// <param name="tasks"></param>
    /// <param name="progress"></param>
    public void UpdateAndSetTasks(List<MissionTaskSystem> tasks, TaskProgress progress)
    {
        this.UpdateTasks(tasks, progress);
    }
    /// <summary>
    /// 更新自己的任务
    /// 这里应该是只显示自己领取的任务
    /// </summary>
    /// <param name="taskType"></param>
    void UpdateTasks(List<MissionTaskSystem> tasks, TaskProgress progress) {
       // List<MissionTaskSystem> list = TaskManager._instance.getTasksByProgress(progress);
        List<MissionTaskSystem> list = tasks;
        if (list.Count < 0) { return; }
        GameObject go = null;
        if (TaskLine == null)
        {
            Debug.LogError("TaskLine预置为空！");
        }
        List<Transform> children = tasksList.GetChildList();
        if (children != null)
        {
            //首先全部清空一次
            for (int i = 0; i < children.Count; i++)
            {
                NGUITools.Destroy(children[i].gameObject);
                tasksList.RemoveChild(children[i]);
            }
        }
        int length = 0;
        foreach (MissionTaskSystem task in list)
        {
            //装备上的以及用完的药品是不能显示的
            if (task.TaskProgress == progress) {
                go = NGUITools.AddChild(tasksList.gameObject, TaskLine);
                go.GetComponent<TaskLine>().SetTask(task);
                length++;
            }  
        }
        //告诉表格排序
        if(go!=null)
        tasksList.AddChild(go.transform);
        tasksList.enabled = true;
    }
    


    /// <summary>
    /// 点击关闭
    /// </summary>
    void CloseTaskPanel() {
        isShowOrHide(false,0);
    }

    /// <summary>
    /// 关闭或者打开窗口
    /// </summary>
    /// <param name="show"></param>
    public void isShowOrHide(bool show,int playid) {
        if (show)
        {
            InitTasks();
            taskParentPanel.PlayForward();
        }
        else {
            taskParentPanel.PlayReverse();
        }
    }

    /// <summary>
    /// 任务列表是由NPC打开的
    /// </summary>
    public void NpcOpenTaskPanel() {
        taskParentPanel.PlayForward();
    }


}
