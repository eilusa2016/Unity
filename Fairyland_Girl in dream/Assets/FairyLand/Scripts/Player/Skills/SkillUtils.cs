using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 技能的工具类
/// 帮助完成各类魔法的释放效果
/// </summary>
public class SkillUtils {

    private SkillUtils() { }
    private static SkillUtils _instance;
    private static object oo = new object();
    private Resources resources;
    private string resourcesMagic_Path = "FairyLand/MagicPrefabs/";
    /// <summary>
    /// Get Util Instance
    /// </summary>
    /// <returns>class Instance</returns>
    public static SkillUtils GetInstance() {
        if (_instance == null) {
            lock (oo) {
                _instance = new SkillUtils();
            }
        }
        return _instance;
    }
    /// <summary>
    /// 实例化魔法的方法
    /// 运动和销毁都在游戏自身的组件上
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="magicName"></param>
    public void RealseMagic(GameObject parent, string magicName,bool needParret) {
        Object ob= Resources.Load(resourcesMagic_Path+ magicName);
        GameObject player=GameObject.FindGameObjectWithTag("Player");

        if (needParret)
        {
            GameObject go = GameObject.Instantiate(ob, parent.transform.position, player.transform.rotation) as GameObject;
            go.transform.SetParent(parent.transform);
        }
        else {
            //这里的物体直接用了钢体,让它自然的落下  否则位置不好控制
            //就像投毒一样
            Vector3 tar = new Vector3(parent.transform.position.x, parent.transform.position.y, parent.transform.position.z);
            GameObject go = GameObject.Instantiate(ob, tar, player.transform.rotation) as GameObject;
        }
      
    }

    /// <summary>
    /// 得到攻击范围内的怪物
    /// </summary>
    /// <param name="transform">玩家人物的对象</param>
    /// <param name="IsForward">是否在前方   false：代表周围</param>
    /// <param name="atkDistance">攻击范围</param>
    /// <returns>返回攻击范围内的所有怪物</returns>
    public List<GameObject> GetMonsterInAtkRange(Transform transform, bool IsForward,float atkDistance) {
        List<GameObject> list = new List<GameObject>();
        List<GameObject> monsters = MonsterManager._monster.GetMosters();
        if (IsForward)
        {
            //前方
            foreach (GameObject go in monsters) {
                //转换成人物的局部坐标，就是和人物的坐标系保持一致
                Vector3 m_pos=transform.InverseTransformPoint(go.transform.position);
                if (m_pos.z > -0.5f) {
                    float dis=Vector3.Distance(Vector3.zero, m_pos);
                    if (dis < atkDistance) {
                        list.Add(go);
                    }
                }
            }
        }
        else {
            //周围
            foreach (GameObject go in monsters) {
                float dis = Vector3.Distance(transform.position, go.transform.position);
                if (dis < atkDistance)
                {
                    list.Add(go);
                }
            }
        }
        return list;
    }


}
