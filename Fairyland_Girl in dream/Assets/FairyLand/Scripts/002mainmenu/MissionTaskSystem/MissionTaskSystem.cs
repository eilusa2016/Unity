using System.Collections;
using System.Collections.Generic;


/// <summary>
/// 任务系统类
/// </summary>
public class MissionTaskSystem {

    #region//任务的各种属性字段
    //Id
    private int _taskId;
    //任务类型（Main,Reward，Daily）
    private TaskType _taskType;
    //名称
    private string _taskName;
    //图标
    private string _taskIcon;
    //任务描述
    private string _taskDes;
    //获得的金币奖励
    private int _taskRewardCoin;
    //获得的钻石奖励
    private int _taskRewardDiamond;
    //跟npc交谈的话语
    private string _taskTalkToNpc;
    //Npc的id
    private int _taskNpcId;
    //副本（任务地点的ID）id
    private int _taskTranscriptId;
    /// <summary>
    /// 任务执行的规定世间
    /// 限时任务才会用到这个
    /// </summary>
    private float _taskExcuteTime;
    /// <summary>
    ///任务的状态:
    ///      i.未开始
    ///      ii.接受任务
    ///      iii.	任务完成
    ///      iv.	获取奖励（结束）
    /// </summary>
    private TaskProgress _taskProgress= TaskProgress.NotStart_1;
    #endregion
   
    #region//封装任务的各种属性字段
    public int TaskId
    {
        get
        {
            return _taskId;
        }

        set
        {
            _taskId = value;
        }
    }

    public TaskType TaskType
    {
        get
        {
            return _taskType;
        }

        set
        {
            _taskType = value;
        }
    }

    public string TaskName
    {
        get
        {
            return _taskName;
        }

        set
        {
            _taskName = value;
        }
    }

    public string TaskIcon
    {
        get
        {
            return _taskIcon;
        }

        set
        {
            _taskIcon = value;
        }
    }

    public string TaskDes
    {
        get
        {
            return _taskDes;
        }

        set
        {
            _taskDes = value;
        }
    }

    public int TaskRewardCoin
    {
        get
        {
            return _taskRewardCoin;
        }

        set
        {
            _taskRewardCoin = value;
        }
    }

    public int TaskRewardDiamond
    {
        get
        {
            return _taskRewardDiamond;
        }

        set
        {
            _taskRewardDiamond = value;
        }
    }

    public string TaskTalkToNpc
    {
        get
        {
            return _taskTalkToNpc;
        }

        set
        {
            _taskTalkToNpc = value;
        }
    }

    public int TaskNpcId
    {
        get
        {
            return _taskNpcId;
        }

        set
        {
            _taskNpcId = value;
        }
    }

    public int TaskTranscriptId
    {
        get
        {
            return _taskTranscriptId;
        }

        set
        {
            _taskTranscriptId = value;
        }
    }

    public TaskProgress TaskProgress
    {
        get
        {
            return _taskProgress;
        }

        set
        {
            _taskProgress = value;
        }
    }

    public float TaskExcuteTime
    {
        get
        {
            return _taskExcuteTime;
        }

        set
        {
            _taskExcuteTime = value;
        }
    }
    #endregion




}
