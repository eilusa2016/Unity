using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 并不是移动的物体的销毁
/// </summary>
public class SkillDestory : MonoBehaviour {

    public float desTime = 10f;
	void Start () {
        Destroy(gameObject, desTime);
	}

    /// <summary>
    /// 使用触发器销毁
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //print("OnTriggerEnter魔法碰到了物体");
        if (other.GetComponent<Collider>().tag != "Player")
        {
            Destroy(gameObject, 2f);
        }

    }
}
