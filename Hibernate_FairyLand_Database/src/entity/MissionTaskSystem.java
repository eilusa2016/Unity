package entity;

import Enums.TaskProgress;
import Enums.TaskType;

/**
 * ����ϵͳ
 * @author Administrator
 *
 */
public class MissionTaskSystem {
	 //Id
    private int _taskId;
    //�������ͣ�Main,Reward��Daily��
    private TaskType _taskType;
    //����
    private String _taskName;
    //ͼ��
    private String _taskIcon;
    //��������
    private String _taskDes;
    //��õĽ�ҽ���
    private int _taskRewardCoin;
    //��õ���ʯ����
    private int _taskRewardDiamond;
    //��npc��̸�Ļ���
    private String _taskTalkToNpc;
    //Npc��id
    private int _taskNpcId;
    //����������ص��ID��id
    private int _taskTranscriptId;
    /// <summary>
    /// ����ִ�еĹ涨����
    /// ��ʱ����Ż��õ����
    /// </summary>
    private float _taskExcuteTime;
    /// <summary>
    ///�����״̬:
    ///      i.δ��ʼ
    ///      ii.��������
    ///      iii.	�������
    ///      iv.	��ȡ������������
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
