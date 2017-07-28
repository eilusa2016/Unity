using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// 游戏玩家自动寻路
/// </summary>
public class PlayerAutoNav : MonoBehaviour {

    private NavMeshAgent agent;
    public Transform target;
    public static PlayerAutoNav _instance;
    private void Awake()
    {
        _instance = this;
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
    }

    private void Update()
    {
        if (IsNavStop(agent, 3f)){
            StopNav();
        }
        //if (Input.GetKeyDown(KeyCode.Space)){
        //    //测试
        //    SetAgentDestination(target.position);
        //}
    }

    /// <summary>
    /// 停止寻路
    /// </summary>
    public void StopNav() {
        if (agent == null) {
            return;
        }
        if (agent.enabled) {
            agent.isStopped = true;
            agent.ResetPath();
            agent.enabled = false;
        }
    }

    /// <summary>
    /// 设置一个寻路的目标
    /// </summary>
    /// <param name="targetPos">目标的坐标</param>
    public void SetAgentDestination(Vector3 targetPos) {
        agent.enabled = true;
        if (!agent.isStopped) {
            agent.SetDestination(targetPos);
        }
    }
    /// <summary>
    /// 导航是否是否已经停止
    /// </summary>
    /// <param name="nav"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
    bool IsNavStop(NavMeshAgent nav,float distance) {
        if (nav == null) {
            return false;
        }
        if (nav.enabled == false)
        {
            return false;
        }
        if (nav.remainingDistance != 0 && nav.remainingDistance < distance) {
            return true;
        }
        return false;
    }


}
