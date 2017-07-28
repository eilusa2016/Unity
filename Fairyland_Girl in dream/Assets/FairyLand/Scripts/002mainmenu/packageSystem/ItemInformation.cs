using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 物品信息类
/// </summary>
[Serializable]
public class ItemInformation {

    //ID
    private int _id;
    //名称
    private string _name;
    //图标 图集中的名称
    private string _icon;
    //物品类型:装备还是药品（Equip，Drug）
    private ItemType _itemtype;

    //装备类型:穿在哪里
    private EquipType equType;
    //售价
    private float _price;
    //星级
    private int _starLevel;
    //品质
    private int  _qualityLevel;
    //伤害
    private int _damage=0;
    //生命
    private int _hp = 0;
    //战斗力
    private int _fightPower=0;
    //作用类型
    private PlayerInfoType _infoType;
    //作用值
    private int _applyValue;
    //描述
    private string _describe;

    //等级和个数是变化的  去掉
    ////装备等级 1
    //private int _level=1;
    ////装备个数
    //private int _count;

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

    public ItemType Itemtype
    {
        get
        {
            return _itemtype;
        }

        set
        {
            _itemtype = value;
        }
    }

    public EquipType EquType
    {
        get
        {
            return equType;
        }

        set
        {
            equType = value;
        }
    }

    public float Price
    {
        get
        {
            return _price;
        }

        set
        {
            _price = value;
        }
    }

    public int StarLevel
    {
        get
        {
            return _starLevel;
        }

        set
        {
            _starLevel = value;
        }
    }

    public int QualityLevel
    {
        get
        {
            return _qualityLevel;
        }

        set
        {
            _qualityLevel = value;
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

    public int Hp
    {
        get
        {
            return _hp;
        }

        set
        {
            _hp = value;
        }
    }

    public int FightPower
    {
        get
        {
            return _fightPower;
        }

        set
        {
            _fightPower = value;
        }
    }

    public PlayerInfoType InfoType
    {
        get
        {
            return _infoType;
        }

        set
        {
            _infoType = value;
        }
    }

    public int ApplyValue
    {
        get
        {
            return _applyValue;
        }

        set
        {
            _applyValue = value;
        }
    }

    public string Describe
    {
        get
        {
            return _describe;
        }

        set
        {
            _describe = value;
        }
    }







}
