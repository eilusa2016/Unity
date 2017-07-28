using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 使用技能的接口
/// 为了以后管理不一样的角色动画
/// </summary>
public interface IPlayAnimation  {
    /// <summary>
    /// 初始化组件
    /// </summary>
     void InitComponent();
    /// <summary>
    /// 初始化动画的状态
    /// </summary>
    void InitAnimation();

    /// <summary>
    /// 普通的攻击
    /// </summary>
    void PlayerNormalAtk();
    /// <summary>
    /// 攻击时候的播放刀光效果的方法
    /// 在动画事件中添加
    /// </summary>
    /// <param name="isShow"></param>
    void ShowSwordLight(string isShow);

    /// <summary>
    /// 魔法攻击
    /// </summary>
    /// <param name="posType"></param>
    void PlayerMagicAtk(SkillPosType posType, bool needParret);


}
