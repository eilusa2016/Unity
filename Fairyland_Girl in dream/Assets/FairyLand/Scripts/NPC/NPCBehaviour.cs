using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 每一个NPC的行为的类
/// </summary>
public class NPCBehaviour : MonoBehaviour {

    /// <summary>
    /// 根据名字来区分是哪一个npc
    /// 如：1001-NPC-Girl
    /// </summary>
    private GameObject npc;
    /// <summary>
    /// 名字的前四个字符是NPC的ID
    /// </summary>
    private int NPCId;
	// Use this for initialization
	void Start () {
        npc = gameObject;
        NPCId = int.Parse(npc.name.Substring(0, 4));
        //使用ID  找到这个NPC上可以领取的任务
        _tasks = TaskManager._instance.getTasksByNpcID(NPCId, TaskProgress.NotStart_1);

    }
    /// <summary>
    /// (1)这个NPC的任务
    /// (2)也可能是一个任务列表
    /// </summary>
    private List<MissionTaskSystem> _tasks;
    /// <summary> 
    /// 任务型NPC的对话内容
    /// </summary>
    public void NPCTalkSomething() {
        string ss = "欢迎来到地狱的入口！ 准备好的话就去桥那边入口.....";
        NPCCommunicatePanel._instance.SetMessage(ss, _tasks);   
    }

    /// <summary>
    /// 关闭NPC的对话框
    /// </summary>
    public void CloseNPCTalkPanel() {
        //关闭对话 
        NPCCommunicatePanel._instance.CloseMessage();
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player") {
            NPCTalkSomething();
        }
       
    }
   

}
