using System.Collections;
using System.Collections.Generic;


/// <summary>
/// 技能
/// </summary>
public class Skill  {

    #region //字段
    //a)	Id
    private int _id;
    //b)	名称
    private string _name;
    //c)	图标
    private string _icon;
    //d)	作用的角色类型(saber   archer  ...)
    private RoleType _role;
    //e)	技能类型（基础攻击， 技能 Basic, Skill,Magic）
    private SkillType _skillType;
    //f)	位置(基础位置，一号技能位置，二号技能位置，三号技能位置 Basic, One, Two, Three)
    private SkillPosType _posType;
    //g)	冷却时间
    private float _coldTime;
    //      持续伤害时间
    private float _continuedTime;
    //h)	基础攻击力
    private int _damage;
    //i)	等级(默认为1级)
    private int _skillLevel=1;

    #endregion

    #region //字段的封装
    public int Id
    {
        get
        {
            return _id;
        }

        set
        {
            _id = value;
        }
    }

    public string Name
    {
        get
        {
            return _name;
        }

        set
        {
            _name = value;
        }
    }

    public string Icon
    {
        get
        {
            return _icon;
        }

        set
        {
            _icon = value;
        }
    }

    public RoleType Role
    {
        get
        {
            return _role;
        }

        set
        {
            _role = value;
        }
    }

    public SkillType SkillType
    {
        get
        {
            return _skillType;
        }

        set
        {
            _skillType = value;
        }
    }

    public SkillPosType PosType
    {
        get
        {
            return _posType;
        }

        set
        {
            _posType = value;
        }
    }

    public float ColdTime
    {
        get
        {
            return _coldTime;
        }

        set
        {
            _coldTime = value;
        }
    }

    public int Damage
    {
        get
        {
            return _damage;
        }

        set
        {
            _damage = value;
        }
    }

    public int SkillLevel
    {
        get
        {
            return _skillLevel;
        }

        set
        {
            _skillLevel = value;
        }
    }
    #endregion



}
