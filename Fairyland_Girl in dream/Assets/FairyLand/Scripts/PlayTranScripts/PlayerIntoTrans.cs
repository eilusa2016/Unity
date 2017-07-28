using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 玩家进入副本（或者是任务的地图）
/// </summary>
public class PlayerIntoTrans : MonoBehaviour {

    /// <summary>
    /// 使用碰撞来检测需要进入哪一个任务
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision == null) {
            return;
        }
        string _tag=collision.collider.tag;

        //if (_tag == "TransScripts") {
        if (TagUtils.GetTagType(_tag) == TagType.TransScripts) { 
            //打开地图选择地图的区域
            string name = collision.collider.gameObject.name;
            string[] arrays = name.Split("-"[0]);
            if (arrays != null && arrays.Length > 1) {
                PlayerPrefs.SetString("_scenceName", arrays[1]);
                SceneManager.LoadScene("LoadingScence");
            }
        }
    }
}
