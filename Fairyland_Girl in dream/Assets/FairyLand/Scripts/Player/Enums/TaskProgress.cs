using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 任务的状态
/// 或者说 任务的进度
/// </summary>
public enum TaskProgress {
    NotStart_1,//未开始(未领取)
    AcceptTask_2,//接受任务(已经领取)
    CompleteTask_3,//任务完成（领取并且完成了任务）
    GetRewardAndEnd_4//获取奖励 结束(完成任务领取奖励)
}

