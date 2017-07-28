using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 怪物的管理组件
/// 附加在 TranscriptManager的GameObject物体上
/// </summary>
public class MonsterManager : MonoBehaviour {

    public static MonsterManager _monster;
    /// <summary>
    /// 玩家
    /// </summary>
    private GameObject _Player;
    /// <summary>
    /// 怪物的集合
    /// </summary>
    private List<GameObject> monsters = new List<GameObject>();
    private GameObject[] mosArrays;
    private void Awake()
    {
        //Resources.LoadAll<GameObject>("");
        _monster = this;
        _Player = GameObject.FindGameObjectWithTag("Player");
        mosArrays= GameObject.FindGameObjectsWithTag("Monster");
        InitMosterList();
    }

    void InitMosterList() {
        if (mosArrays == null) {
            return;
        }
        foreach (GameObject ob in mosArrays) {
            monsters.Add(ob);
        }
    }

    /// <summary>
    /// 得到所有怪物的集合
    /// </summary>
    /// <returns></returns>
    public List<GameObject> GetMosters() {
        return monsters;
    }

    public GameObject GetPlayer() {
        return _Player;
    }
}
