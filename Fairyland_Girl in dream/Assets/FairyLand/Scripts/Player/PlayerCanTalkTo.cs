using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 玩家是否可以和NPC之类的对话
/// 就是做些射线检测
/// </summary>
public class PlayerCanTalkTo : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        Vector3 orPos = transform.position;
        Vector3 direction = transform.forward * (1.01f) - orPos;
        //射线的长度
        //float shootLength = direction.magnitude;
        float shootLength =5f;
       // print("shootLength="+ shootLength);
        //射线检测  检查是否碰撞
        RaycastHit hitInfo;
        bool isCollider = Physics.Raycast(orPos, direction, out hitInfo, shootLength);
        if (isCollider)
        {
            NPCBehaviour beav= hitInfo.collider.GetComponent<NPCBehaviour>();
            //撞到了NPC 然后可以对话  当然 也可以使用碰撞器来触发
            if (hitInfo.collider.tag == "NPC")
            {
               // hitInfo.collider.GetComponent<NPCBehaviour>().NPCTalkSomething();
            }
           
        }
    }
}
