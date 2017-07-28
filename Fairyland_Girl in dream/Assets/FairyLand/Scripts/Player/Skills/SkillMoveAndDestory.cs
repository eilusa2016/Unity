using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMoveAndDestory : MonoBehaviour {


    public float speed = 10f;
    public float NormalDesTime = 15f;
    private float damage;//伤害
    private void Start()
    {
        Destroy(gameObject, NormalDesTime);
    }
    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.forward * speed);
	}
    /// <summary>
    /// 魔法撞到的物体的时候
    /// （但是这个要加上钢体  加上钢体就会碰到人体自动消灭）
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        print("OnCollisionEnter魔法碰到了物体");
        if (collision.collider) {
            Destroy(gameObject,1f);
        }
    }
    /// <summary>
    /// 使用触发器销毁
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        print("OnTriggerEnter魔法碰到了物体");
        if (other.GetComponent<Collider>().tag != "Player") {
            Destroy(gameObject, 2f);
        }
       
    }

}
