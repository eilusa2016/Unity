using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 玩家点击屏幕上的技能按钮
/// </summary>
public class PlayerUseSkills : MonoBehaviour {

    public static PlayerUseSkills _instance;
   
    UIButton normalAtk;
    UIButton magic1;
    UIButton magic2;
    UIButton magic3;
    UISprite mask1, mask2, mask3;
    float Magic1ColudTime = 2f;//两秒钟冷却一次
    float Magic2ColudTime = 2f;//两秒钟冷却一次
    float Magic3ColudTime = 2f;//两秒钟冷却一次
    float ColudTimer1 = 0f;//冷却用的计时器
    float ColudTimer2 = 0f;//冷却用的计时器
    float ColudTimer3 = 0f;//冷却用的计时器
    public float maskStep = 0.1f;//每次冷却减少计时
    private IPlayAnimation playAni;
    AnimationFactory _factory;
    private void Awake()
    {
        _instance = this;
        normalAtk = transform.Find("NormalAtk").GetComponent<UIButton>();
        magic1 = transform.Find("Magic1").GetComponent<UIButton>();
        magic2 = transform.Find("Magic2").GetComponent<UIButton>();
        magic3 = transform.Find("Magic3").GetComponent<UIButton>();
       
        mask1 = magic1.transform.Find("Mask").GetComponentInChildren<UISprite>();
        mask2 = magic2.transform.Find("Mask").GetComponentInChildren<UISprite>();
        mask3 = magic3.transform.Find("Mask").GetComponentInChildren<UISprite>();
       
        mask1.fillAmount = 0f;
        mask2.fillAmount = 0f;
        mask3.fillAmount = 0f;

        _factory = AnimationFactory.getAniFactory();
        normalAtk.onClick.Add(new EventDelegate(this,"NormalAtkSkill"));
        magic1.onClick.Add(new EventDelegate(this, "MagicAtkSkill_1"));
        magic2.onClick.Add(new EventDelegate(this, "MagicAtkSkill_2"));
        magic3.onClick.Add(new EventDelegate(this, "MagicAtkSkill_3"));

        UIEventListener.Get(magic1.gameObject).onHover = ButtonOnHover;
        UIEventListener.Get(magic2.gameObject).onHover = ButtonOnHover;
        UIEventListener.Get(magic3.gameObject).onHover = ButtonOnHover;
    }
    /// <summary>
    /// 鼠标悬停
    /// </summary>
    /// <param name="go"></param>
    /// <param name="state"></param>
    private void ButtonOnHover(GameObject go, bool state)
    {
        if (state)
        {
            iTween.ScaleTo(go, new Vector3(1.1f, 1.1f, 1.1f), 0.1f);
        }
        else {
            iTween.ScaleTo(go, new Vector3(1f, 1f, 1f), 0.1f);
        }
    }





    /// <summary>
    /// 普通的攻击
    /// </summary>
    void NormalAtkSkill() {
        playAni = _factory.GetPlayerAniComponent(PlayerAniModeType.YuKa);
        playAni.PlayerNormalAtk();
    }

    /// <summary>
    /// Magic1的攻击
    /// </summary>
    void MagicAtkSkill_1()
    {
        playAni = _factory.GetPlayerAniComponent(PlayerAniModeType.YuKa);
        playAni.PlayerMagicAtk(SkillPosType.Magic1,true);
        mask1.fillAmount = 1f;
        magic1.enabled = false;
    }
    /// <summary>
    /// Magic2的攻击
    /// </summary>
    void MagicAtkSkill_2()
    {
        playAni = _factory.GetPlayerAniComponent(PlayerAniModeType.YuKa);

        playAni.PlayerMagicAtk(SkillPosType.Magic2,false);
        mask2.fillAmount = 1f;
        magic2.enabled = false;

    } /// <summary>
      /// Magic3的攻击
      /// </summary>
    void MagicAtkSkill_3()
    {
        playAni = _factory.GetPlayerAniComponent(PlayerAniModeType.YuKa);

        playAni.PlayerMagicAtk(SkillPosType.Magic3,true);
        mask3.fillAmount = 1f;
        magic3.enabled = false;
    }

    private void Update()
    {

        #region 每一帧冷却一部分
       
        if (mask1.fillAmount >0f)
        {
            ColudTimer1 += Time.deltaTime;
            if (ColudTimer1 > Magic1ColudTime)
            {
                mask1.fillAmount -= maskStep;
                ColudTimer1 -= Magic1ColudTime;
            }
        }
        else if (mask1.fillAmount <= 0f)
        {
            mask1.fillAmount = 0f;
            magic1.enabled = true;
            ColudTimer1 = 0f;
        }
        if (mask2.fillAmount >0f)
        {
            ColudTimer2 += Time.deltaTime;
            if (ColudTimer2 > Magic2ColudTime)
            {
                mask2.fillAmount -= maskStep;
                ColudTimer2 -= Magic2ColudTime;
            }
        }
        else if (mask2.fillAmount <= 0f)
        {
            mask2.fillAmount = 0f;
            magic2.enabled = true;
            ColudTimer2 = 0f;
        }
        if (mask3.fillAmount >0f)
        {
            ColudTimer3 += Time.deltaTime;
            if (ColudTimer3 > Magic3ColudTime)
            {
                mask3.fillAmount -= maskStep;
                ColudTimer3 -= Magic3ColudTime;
            }
        }
        else if(mask3.fillAmount<=0)
        {
            mask3.fillAmount = 0f;
            magic3.enabled = true;
            ColudTimer3 = 0f;
        }
        #endregion
    }

}
