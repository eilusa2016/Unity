using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
/// <summary>
/// YuKa模型的动画
/// </summary>
public class PlayerYuKAnimation : MonoBehaviour ,IPlayAnimation{

	private Animator anim;
    private AnimatorStateInfo animatorInfo;
    private AnimatorStateInfo animatorInfoAtk;
    public static PlayerYuKAnimation _instance;
    private ParticleSystem _swordLight;
    private SkillUtils _skillUtils;
    private GameObject magicFactory;
    private GameObject FrontGroundPos;
    private IWeapon weapon;
    private CharacterController characterController;

    private void Awake()
    {
        InitComponent();
    }

   

    void Update () {
        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");
        InitAnimation();
       // print("characterController.velocity=" + characterController.velocity);
       // if (characterController.velocity.magnitude > 0f) {
            if (y> 0)
            {
                anim.SetBool("isRun", true);
            }
            if (y < 0)
            {
                anim.SetBool("isBack", true);
            }
       // }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isJump", true);
        }
        OnPlayerAtkAni();
    }
    private bool swordSkill = false;
    /// <summary>
    /// 当攻击的时候播放哪个动画
    /// </summary>
    public void OnPlayerAtkAni() {
        //if(Input.GetKeyDown(KeyCode.F)){
        //    anim.SetTrigger("AtkTrig");
        //}
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            bool flag = !swordSkill;
            swordSkill = flag;
            anim.SetBool("skill1", flag);
            Weapon.SetWeaponStatus(1, flag);
        }
        //else {
        //    anim.SetBool("skill1", false);
        //}
    }



    #region//初始化组件一起一些公用的方法
    public void InitComponent()
    {
        _instance = this;
        anim = GetComponent<Animator>();
        _skillUtils = SkillUtils.GetInstance();
        animatorInfo = anim.GetCurrentAnimatorStateInfo(0);
        animatorInfoAtk= anim.GetCurrentAnimatorStateInfo(1);
        characterController = GetComponent<CharacterController>();
          _swordLight = transform.Find("katanaPos/Slash10").GetComponent<ParticleSystem>();
        _swordLight.Stop();
        magicFactory = transform.Find("MagicFactory").gameObject;
        FrontGroundPos = transform.Find("FrontGroundPos").gameObject;
    }
    /// <summary>
    /// 初始化动画
    /// </summary>
    public void InitAnimation()
    {

        anim.SetBool("isJump", false);
        anim.SetBool("isBack", false);
        anim.SetBool("isAtk", false);
        anim.SetBool("isRun", false);
        //anim.SetBool("skill1", false);
    }

    int normalCount = 0;
    float normalCountTimer = 0f;
    public IWeapon Weapon
    {
        get
        {
            if (weapon == null) {
                weapon = Katana._inttsance;
            }
            return weapon;
        }

        set
        {
            weapon = value;
        }
    }

    /// <summary>
    /// 普通的攻击
    /// 这里最好使用函数帧事件来触发刀光效果
    /// 注意Animator在哪个对象上
    /// 这个方法的组件也要在哪个对象上
    /// </summary>
    public void PlayerNormalAtk() {
        anim.SetTrigger("AtkTrig");
       
        float des = 1f;
        //每次攻击向前移动  des的距离 暂时不用
       // transform.Translate(Vector3.forward * des);
    }
    /// <summary>
    /// 这个方法是在动画里面插入函数帧动画事件来触发
    /// </summary>
    /// <param name="isShow">参数是字符转形式的 true,damage..这样的形式  后面会处理修改在动画帧事件里面</param>
    public void ShowSwordLight(string isShow) {
        bool flag=bool.Parse(isShow);
        if (flag) {
            PlaySoundManager._instance.PlayMusicByName("mai_free_02_attack2");
            _swordLight.Play();
        } 
    }

    //IEnumerator StopParticleLoop(ParticleSystem psm,float waitTime) {
    //    yield return new WaitForSeconds(waitTime);
    //    ParticleSystem.MainModule m = psm.main;
    //    m.loop = false;
    //    psm.Stop();
    //    normalCount = 0;
    //}
    
        /// <summary>
    /// 魔法攻击
    /// </summary>
    /// <param name="posType">按键的位置</param>
    public void PlayerMagicAtk(SkillPosType posType,bool needParret) {
        anim.SetBool("skill1", true);
        PlaySoundManager._instance.PlayMusicByName("mai_free_05_hehehe");
        switch (posType) {
            case SkillPosType.Basic:
                break;
            case SkillPosType.Magic1:
                _skillUtils.RealseMagic(magicFactory, "FireBall", needParret);
                break;
            case SkillPosType.Magic2:
                //Swamp
                _skillUtils.RealseMagic(FrontGroundPos, "Swamp", needParret);
                break;
            case SkillPosType.Magic3:
                //IceBall
                _skillUtils.RealseMagic(magicFactory, "IceBall", needParret);
                break;

        }
        StartCoroutine(LazyStopSkill());
    }

    IEnumerator LazyStopSkill() {
        yield return new WaitForSeconds(1f);
        anim.SetBool("skill1", false);
        
    }


    #endregion
}
