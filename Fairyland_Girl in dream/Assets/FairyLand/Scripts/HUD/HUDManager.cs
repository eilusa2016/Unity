using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 抬头显示控制器
/// </summary>
public class HUDManager : MonoBehaviour {

    public static HUDManager _instance;
    public GameObject MonsterHPBarPrefab;
    private void Awake()
    {
        _instance = this;
    }
    private UIFollowTarget followTarget;
    /// <summary>
    /// 怪物的HUD的添加
    /// </summary>
    /// <param name="target">更随目标</param>
    /// <returns>返回hpbar</returns>
    public GameObject AddMonsterHPBar(GameObject target) {
        if (MonsterHPBarPrefab == null) {
            Debug.LogError("MonsterHPBarPrefab==null");
            return null;
        }
        GameObject go = NGUITools.AddChild(gameObject, MonsterHPBarPrefab);
        followTarget=go.GetComponent<UIFollowTarget>();
        followTarget.target = target.transform;
        return go;
    }

}
