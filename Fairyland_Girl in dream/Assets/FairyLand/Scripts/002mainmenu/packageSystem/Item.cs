using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 物品类(中间类)多对多
/// 表示一个物品项
/// 一般一个武平信息类代表一个物品
/// 其实不然：
/// 游戏中：一个人持有多件同一种物品
///         或者说  一个人持有多件  不同等级的  同一种物品
///         这样的话  单一的类就会出现矛盾   又不可能在玩家累中区修改
///         很熟悉：  数据库的  多对多 的设计思想
///         这里设计为：同一类型的要药品放在同一个格子
///                     同一个类型的装备放在不同的格子
/// </summary>
[Serializable]
public class Item {
    //名称
    private string _name;
    //物品类型:装备还是药品（Equip，Drug）
    private ItemType _itemtype;
    //是哪一个物品
    private ItemInformation _itemInfo;
    //物品等级
    private int _level;
    //物品个数
    private int _count;
    //是否已经装备上了
    private bool _dressed=false;

    #region//封装字段
    public int Level
    {
        get
        {
            return _level;
        }

        set
        {
            _level = value;
        }
    }

    public int Count
    {
        get
        {
            return _count;
        }

        set
        {
            _count = value;
        }
    }

    public ItemInformation ItemInfo
    {
        get
        {
            return _itemInfo;
        }

        set
        {
            _itemInfo = value;
        }
    }

    public bool Dressed
    {
        get
        {
            return _dressed;
        }

        set
        {
            _dressed = value;
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
    #endregion
}
