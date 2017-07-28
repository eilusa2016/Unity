using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 玩家的技能
/// 但是一开始是不能全部点亮的
/// 因该技能的树
/// 
/// 这个技能的面板会重新设计过的
/// </summary>
public class SkillPanel : MonoBehaviour {
    public static SkillPanel _instance;

    private TweenAlpha alpha;
    private bool isShows = false;
    private void Awake()
    {
        _instance = this;
        alpha = GetComponent<TweenAlpha>();
        alpha.PlayReverse();//先隐藏
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            if (isShows)
            {
                CloseSkillPanel();
            }
            else {
                OpenSkillPanel();
            }
        }
    }

    //打开
    public void OpenSkillPanel() {
        alpha.PlayForward();
        isShows = true;
    }
    //关闭
    public void CloseSkillPanel() {
        alpha.PlayReverse();//先隐藏
        isShows = false;
    }
}
