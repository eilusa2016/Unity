using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 管理技能的组件
/// </summary>
public class SkillManager : MonoBehaviour {
    public static SkillManager _instance;
    public TextAsset skilltext;
    private List<Skill> skills = new List<Skill>();
    private PlayerSkills _playerSkills;
    private void Awake()
    {
        _instance = this;
        InitReadSkills();
       
    }
    private void Start()
    {
        InitPlayerSkills();
    }
    /// <summary>
    /// 初始化读取技能列表
    /// </summary>
    void InitReadSkills() {
        if (skilltext == null) {
            return;
        }
        string[] linearrays = skilltext.ToString().Split("\n"[0]);
        for (int i = 0; i < linearrays.Length; i++) {
            string str = linearrays[i];
            string[] arrays = str.Split(","[0]);
            Skill skill = new Skill();
            skill.Id = GameController.ParseInt(arrays[0]);
            skill.Name = arrays[1];
            skill.Icon = arrays[2];
            skill.Role = GameController.GetRoleType(arrays[3]);
            skill.SkillType = GameController.GetSkillType(arrays[4]);
            skill.PosType =GameController.GetSkillPosType(arrays[5]);
            skill.ColdTime = 5f;
            skill.Damage = GameController.ParseInt(arrays[6]);
            skill.SkillLevel = GameController.ParseInt(arrays[7]);
            skills.Add(skill);
        }

    }
    /// <summary>
    /// 获得技能的集合
    /// </summary>
    /// <returns></returns>
    public List<Skill> GetAllSkills() {

        return this.skills;
    }

    /// <summary>
    /// 初始化读取当前玩家的技能
    /// </summary>
    void InitPlayerSkills() {
        if (_playerSkills==null) {
            _playerSkills = new PlayerSkills(); ;
        }
        if (_playerSkills.GamerSkills == null) {
            _playerSkills.GamerSkills = new List<Skill>();
        }
        int playerID = PlayerInformation._instance.PlayerID;
        //这一步应该是从数据库读取当前玩家的技能列表

        List<Skill> skills = GetAllSkills();
        for (int i = 0; i < skills.Count; i++) {
            Skill sk = skills[i];
            _playerSkills.PlayerID = playerID;
            _playerSkills.GamerSkills.Add(sk);
        }

    }

    /// <summary>
    /// 得到当前玩家的玩家的技能
    /// </summary>
    /// <returns></returns>
    public PlayerSkills GetPlayerSkills() {

        return this._playerSkills;
    }

    /// <summary>
    /// 释放攻击
    /// </summary>
    public  void Releaseattack() {

    }


}
