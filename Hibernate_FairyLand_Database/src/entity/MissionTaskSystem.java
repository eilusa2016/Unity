package entity;

import Enums.TaskProgress;
import Enums.TaskType;

/**
 * 任务系统
 * @author Administrator
 *
 */
public class MissionTaskSystem {
	 //Id
    private int _taskId;
    //任务类型（Main,Reward，Daily）
    private TaskType _taskType;
    //名称
    private String _taskName;
    //图标
    private String _taskIcon;
    //任务描述
    private String _taskDes;
    //获得的金币奖励
    private int _taskRewardCoin;
    //获得的钻石奖励
    private int _taskRewardDiamond;
    //跟npc交谈的话语
    private String _taskTalkToNpc;
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
    
	public MissionTaskSystem(int _taskId, TaskType _taskType, String _taskName, String _taskIcon, String _taskDes,
			int _taskRewardCoin, int _taskRewardDiamond, String _taskTalkToNpc, int _taskNpcId, int _taskTranscriptId,
			float _taskExcuteTime, TaskProgress _taskProgress) {
		super();
		this._taskId = _taskId;
		this._taskType = _taskType;
		this._taskName = _taskName;
		this._taskIcon = _taskIcon;
		this._taskDes = _taskDes;
		this._taskRewardCoin = _taskRewardCoin;
		this._taskRewardDiamond = _taskRewardDiamond;
		this._taskTalkToNpc = _taskTalkToNpc;
		this._taskNpcId = _taskNpcId;
		this._taskTranscriptId = _taskTranscriptId;
		this._taskExcuteTime = _taskExcuteTime;
		this._taskProgress = _taskProgress;
	}
	public int get_taskId() {
		return _taskId;
	}
	public void set_taskId(int _taskId) {
		this._taskId = _taskId;
	}
	public TaskType get_taskType() {
		return _taskType;
	}
	public void set_taskType(TaskType _taskType) {
		this._taskType = _taskType;
	}
	public String get_taskName() {
		return _taskName;
	}
	public void set_taskName(String _taskName) {
		this._taskName = _taskName;
	}
	public String get_taskIcon() {
		return _taskIcon;
	}
	public void set_taskIcon(String _taskIcon) {
		this._taskIcon = _taskIcon;
	}
	public String get_taskDes() {
		return _taskDes;
	}
	public void set_taskDes(String _taskDes) {
		this._taskDes = _taskDes;
	}
	public int get_taskRewardCoin() {
		return _taskRewardCoin;
	}
	public void set_taskRewardCoin(int _taskRewardCoin) {
		this._taskRewardCoin = _taskRewardCoin;
	}
	public int get_taskRewardDiamond() {
		return _taskRewardDiamond;
	}
	public void set_taskRewardDiamond(int _taskRewardDiamond) {
		this._taskRewardDiamond = _taskRewardDiamond;
	}
	public String get_taskTalkToNpc() {
		return _taskTalkToNpc;
	}
	public void set_taskTalkToNpc(String _taskTalkToNpc) {
		this._taskTalkToNpc = _taskTalkToNpc;
	}
	public int get_taskNpcId() {
		return _taskNpcId;
	}
	public void set_taskNpcId(int _taskNpcId) {
		this._taskNpcId = _taskNpcId;
	}
	public int get_taskTranscriptId() {
		return _taskTranscriptId;
	}
	public void set_taskTranscriptId(int _taskTranscriptId) {
		this._taskTranscriptId = _taskTranscriptId;
	}
	public float get_taskExcuteTime() {
		return _taskExcuteTime;
	}
	public void set_taskExcuteTime(float _taskExcuteTime) {
		this._taskExcuteTime = _taskExcuteTime;
	}
	public TaskProgress get_taskProgress() {
		return _taskProgress;
	}
	public void set_taskProgress(TaskProgress _taskProgress) {
		this._taskProgress = _taskProgress;
	}
    
}
