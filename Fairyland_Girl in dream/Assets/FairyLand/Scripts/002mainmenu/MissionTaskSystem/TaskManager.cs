using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 任务管理类
/// </summary>
public class TaskManager : MonoBehaviour {

    public static TaskManager _instance;
    public TextAsset taskListAsset;
    public static List<MissionTaskSystem> allList = new List<MissionTaskSystem>();

    private void Awake()
    {
        _instance = this;
        InitTaskList();
    }

    public delegate void OnTaskListChangedEvent(TaskProgress progress);
    /// <summary>
    /// 检查任务是否完成
    /// </summary>
    public delegate void OnCheckTaskCompleteEvent();
    /// <summary>
    /// 任务已经完成
    /// </summary>
    public delegate void OnTaskCompletedEvent();
    /// <summary>
    /// 当任务列表发生变化时触发
    /// </summary>
    public event OnTaskListChangedEvent OnTaskListChanged;
  
    
    
    
    
    
    
    /// <summary>
    /// 外界调用的
    /// 任务列表属性发生改变的方法
    /// </summary>
    /// <param name="taskType"></param>
    public void StartTaskListChange(TaskProgress progress) {
        OnTaskListChanged(progress);
    }
    /// <summary>
    /// 获得任务
    ///  根据任务的进度
    /// </summary>
    /// <param name="progress"></param>
    /// <returns></returns>
    public List<MissionTaskSystem> getTasksByProgress(TaskProgress progress) {
        List<MissionTaskSystem> list = new List<MissionTaskSystem>();
        if (allList == null) {
            return list;
        }
        for (int i = 0; i < allList.Count; i++) {
            if (allList[i].TaskProgress == progress) {
                list.Add(allList[i]);
            }

        }
        return list;
    }


    /// <summary>
    /// 根据NPCID
    /// 找到对应的任务
    /// </summary>
    /// <param name="NPC_ID">NPC的编号</param
    /// <param name="progress">任务的进度</param>
    /// <returns></returns>
    public List<MissionTaskSystem> getTasksByNpcID(int NPC_ID, TaskProgress progress)
    {
        List<MissionTaskSystem> list = new List<MissionTaskSystem>();
        if (allList == null)
        {
            return list;
        }
        for (int i = 0; i < allList.Count; i++)
        {
            if (allList[i].TaskNpcId== NPC_ID&& allList[i].TaskProgress == progress)
            {
                list.Add(allList[i]);
            }

        }
        return list;
    }
    /// <summary>
    /// 初始化任务列表
    /// 所有任务
    /// </summary>
    public void InitTaskList() {
        if (taskListAsset == null) {
            GameController.DebugLog("taskListAsset资源文件为空", true);
            return;
        }
        string[] TaskArray=taskListAsset.ToString().Split("\n"[0]);
        foreach(string LineStr in TaskArray) {
            string[]  array=LineStr.Split("|"[0]);
            MissionTaskSystem task = new MissionTaskSystem();
            task.TaskId = GameController.ParseInt(array[0]);
            task.TaskType = GameController.GetTaskType(array[1]);
            task.TaskName = array[2];
            task.TaskIcon = array[3];
            task.TaskDes = array[4];
            task.TaskRewardCoin = GameController.ParseInt(array[5]);
            task.TaskRewardDiamond = GameController.ParseInt(array[6]);
            task.TaskTalkToNpc = array[7];//NPC对话内筒
            task.TaskNpcId = GameController.ParseInt(array[8]);//npcid
            task.TaskTranscriptId = GameController.ParseInt(array[9]);//副本的id
            task.TaskProgress = TaskProgress.NotStart_1;//任务的状态
            allList.Add(task);
        }


    }



    private MissionTaskSystem currentTask;
    /// <summary>
    /// 执行任务
    /// </summary>
    /// <param name="task"></param>
    /// <param name="playerID">玩家的ID</param>
    public void ExcuteTask(MissionTaskSystem task,int playerID) {
        currentTask = task;
        if (task.TaskProgress == TaskProgress.NotStart_1)
        {
            #region //任务还未开始
            //网游的话就要导航到副本  或者到某个NPC的下面
            //这里自己的游戏设计上  不用这样
            // 一般是领取任务   做不做完全没关系,当然  主线任务还是要做的
            //try
            //{
            //    Vector3 tarPos = NPCManager._instance.GetNPCByID(task.TaskNpcId).transform.position;
            //    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAutoNav>().SetAgentDestination(tarPos);
            //}
            //catch (System.Exception e)
            //{

            //    Debug.Log("自动导航到NPC异常:" + e.Message);
            //}
            #endregion

            //上面是测试代码，在所有任务的页面领取任务会跑到NPC那里
            //可是问题来了  任务的执行地点不一定在NPC所在位置的
            //还是得人走过去的
            task.TaskProgress = TaskProgress.AcceptTask_2;//任务进度改成已经领取执行


        }
        else if (task.TaskProgress == TaskProgress.AcceptTask_2) {
            //对于已经领取执行的任务  
            //已经领取  就要去执行
            OnAcceptTask();
        }

    }

    /// <summary>
    /// 执行任务
    /// 这个比较麻烦
    /// 情况较多
    /// 走到任务地点出发执行
    /// 还有做些东西就检查是否已经执行了
    /// </summary>
    public void OnAcceptTask() {
        //currentTask.TaskProgress = TaskProgress.AcceptTask_2;
    }


    /// <summary>
    /// 到达并且进入执行
    /// 这个方法的话使用自动寻路到达目的地后
    /// 然后看是否当前执行的任务
    /// </summary>
    public void ArriveToTransScript() {
        if (currentTask == null) {
            //NPCCommunicatePanel._instance
            return;
        }
        if (currentTask.TaskProgress == TaskProgress.NotStart_1) {
            //执行任务
          //TODO
        }
    }


}
