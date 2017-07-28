using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// NPC的管理类
/// 包括管理和加载所有的NPC
/// 当然 这个类是可以管理所有任务执行地点（副本）的位置的
/// </summary>
public class NPCManager : MonoBehaviour {

    public static NPCManager _instance;
    public GameObject[] NPCS;
    public static Dictionary<int, GameObject> NPCSDic = new Dictionary<int, GameObject>();

    private void Awake()
    {
        _instance = this;
        if (NPCSDic.Count <= 0) {
            InitNpcs();
        }
       
    }

    /// <summary>
    /// 初始化读取NPC
    /// </summary>
    void InitNpcs() {
        if (NPCS == null) {
            return;
        }
        foreach(GameObject oo in NPCS){
            int id = int.Parse(oo.name.Substring(0, 4));
            NPCSDic.Add(id, oo);
        }
    }
    /// <summary>
    /// 得到NPC
    /// </summary>
    /// <param name="id">NPCID</param>
    /// <returns></returns>
    public GameObject GetNPCByID(int id) {
        if (NPCSDic.Count < 1) {
            return null;
        }
        GameObject npc = null;
        NPCSDic.TryGetValue(id, out npc);
        return npc;
    } 
}
