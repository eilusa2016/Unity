using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 任务类型
/// （Main:主线任务,Reward：赏金任务（支线），Daily：日常）
///  timely  及时或者说是限定时间的任务
/// </summary>
public enum TaskType {
    Main,
    Reward,
    Daily,
    timely
}