using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 刀剑katana的武器组件
/// </summary>
public class Katana : MonoBehaviour,IWeapon {


    public static Katana _inttsance;
    public GameObject[] weaponLights;

    private void Awake()
    {
        _inttsance = this;
        InitWeaponLights();
    }
    void InitWeaponLights() {
        if (weaponLights == null) {
            return;
        }
        foreach (GameObject oo in weaponLights) {
            oo.SetActive(false);
        }
    }
    /// <summary>
    /// 设置刀剑光芒的状态
    /// </summary>
    /// <param name="index"></param>
    /// <param name="isopen"></param>
    public void SetWeaponStatus(int index, bool isopen) {
        if (weaponLights == null) {
            return;
        }
        if (index < weaponLights.Length) {
            weaponLights[index].SetActive(isopen);
        }
    }
    /// <summary>
    /// 刀剑碰到了物体
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        
        CheckWeaponCollider(other);
    }


    void CheckWeaponCollider(Collider other) {
        if (TagUtils.GetTagType(other.tag) == TagType.Monster) {
            
           // other.transform.SendMessage("BeHitAndDamaged", "");
            //与附加碰撞器边界框最近的点。
            // Vector3 pos=other.ClosestPointOnBounds(transform.position);
        }
    }




}
