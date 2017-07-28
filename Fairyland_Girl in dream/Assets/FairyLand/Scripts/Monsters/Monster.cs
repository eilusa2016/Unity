using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// 怪物的脚本
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class Monster : MonoBehaviour {

    public GameObject prefab;
    private float bolldHp=100;//血量
    private float bolldHpTotal = 100;//总的血量
    private Animation ani;
    private CharacterController _moveController;
    public float moveSpeed = 1f;//怪物的移动速度
                //几秒攻击一次                    攻击距离
    public float atkSpeed = 2f, atkSpeedTimer=0f,atkDistance=4f,distance=0f;
    public float atkRoundDistance = 10f;//察觉到玩家的范围
    private NavMeshAgent agent;//导航的网格

    //血条更随的位置
    private Transform bloodPos;
    //血条
    private UISlider bloodSlider;
    //血条
    private GameObject bloodObject;
    private void Awake()
    {
        ani=GetComponent<Animation>();
        _moveController = GetComponent<CharacterController>();
        agent = GetComponent<NavMeshAgent>();
        try
        {
            bloodPos = transform.Find("bloodPos");
        }
        catch {
            Debug.LogError("怪物的血条位置=>bloodPos没有!");
        }
    }
    
    private void Start()
    {
        InvokeRepeating("CalcDistance",0f,0.1f);
        //添加血条
        bloodObject=HUDManager._instance.AddMonsterHPBar(bloodPos.gameObject);
        bloodSlider = bloodObject.transform.Find("bg").GetComponent<UISlider>();
        //agent.SetDestination(MonsterManager._monster.GetPlayer().transform.position);
    }
    void CalcDistance() {
        distance= Vector3.Distance(transform.position, MonsterManager._monster.GetPlayer().transform.position);
        //print("distance=" + distance);
    }
    private void Update()
    {
        
        if (distance <= atkDistance)
        {
            atkSpeedTimer += Time.deltaTime;
            if (atkSpeedTimer >= atkSpeed)
            {
                atkSpeedTimer -= atkSpeed;
                //播放攻击动画
                ani.Play("attack01");
            }
        }
        else {
            atkSpeedTimer = 0f;
            if (distance <= atkRoundDistance) {
                //一定的范围内才会追击玩家
                MonsterMove();
            }
           
        }
       
    }
    /// <summary>
    /// 被物体攻击的时候
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        Combo._combo.AddCombo();
        if (bolldHp < 0) {
            return;
        }
        if (TagUtils.GetTagType(other.tag) == TagType.katana)
        {
            //被刀剑砍刀会流血  魔法什么的  直接烧焦
            Vector3 pos = other.ClosestPointOnBounds(transform.position);
            BeHitAndDamaged(prefab, pos);
        }
        else if (TagUtils.GetTagType(other.tag) == TagType.Magic) {
            GameObject go=Resources.Load<GameObject>("FairyLand/MagicPrefabs/LaserFire2");
            BeHitAndDamaged(go, transform.position);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="values">字符串类型可以根据特殊字符分割</param>
    void BeHitAndDamaged(GameObject go,Vector3 pos) {
        float percent=bolldHp / bolldHpTotal;
        
        bloodSlider.value = percent;//更新怪物的血量
        //出血的特效
        if (go == null) {
            Debug.LogError("特效为空");
            return;
        }
        //bolldHp -= 20f;//伤害
        ani.Play("takedamage");
        GameObject.Instantiate(go, pos, Quaternion.identity);
        if (bolldHp < 0) {
            //怪物死亡
            MonsterDead();
        }
    }

    void MonsterDead() {
        ani.Play("die");
        //死亡销毁这只怪物
        Destroy(bloodPos, 0.1f);
        Destroy(gameObject,2f);
        
    }




    /***********以下是AI控制怪物行走**********/
    void MonsterMove() {
        ani.Play("walk");
        Transform player = MonsterManager._monster.GetPlayer().transform;
        Vector3 targetPos = player.position;  
        transform.LookAt(targetPos);
        targetPos = targetPos - transform.position;
        //向玩家移动
        //_moveController.SimpleMove(targetPos*Time.deltaTime);
        _moveController.SimpleMove(transform.forward*moveSpeed);
        
    }



}
