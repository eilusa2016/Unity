using UnityEngine;
using System;
/// <summary>
/// 单机玩家的属性
/// </summary>
[Serializable]
public class PlayerProperty {
    //玩家的编号
    private int playerId;
    //序列
    private int serNo;
    //玩家的角色名称
    private string playerName;
    //头像
    private string _headPortrail;
    //等级
    private int _level = 1;
    //战斗力
    private int _power = 1;
    //经验数
    private int _exp = 0;
    private int _expMax = 0;
    //钻石数
    private int _diamond = 0;
    //金币数
    private int _coin;
    //体力数 hp
    private int _energy;
    private int _energyMax;//体力上限
    //历练数  这里表示sp
    private int _toughen;
    private int _toughenMax;//sp上限
    private int damage;//伤害


    //玩家所选区域
    private string playArea;

    //是否是正玩的记录
    private bool isPlaying;
    /// <summary>
    ///上次登录的时间
    /// </summary>
    private DateTime loginDate;
    //经验值
    private float experience;
    //游戏对象的模型
    private string playModelName;

    public void setValues(int playerId, int serNo, string playerName, string playArea, int playLevel, bool isPlaying, int playH, int playM, DateTime loginDate,GameObject go) {

        this.playerId = playerId;
        this.serNo = serNo;
        this.playerName = playerName;
        this.playArea = playArea;
        this.Level = playLevel;
        this.isPlaying = isPlaying;
        this.Energy = playH;
        this.Toughen = playM;
        this.loginDate = loginDate;
        this.playModelName = go.name;
    }

    /// <summary>
    /// 是否是同一条记录
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public bool Equals(PlayerProperty obj)
    {
        if (obj == null) {
            return false;
        }
        if (this.PlayerId == obj.PlayerId && this.SerNo == obj.SerNo)
        {

            return true;
        }
        return false;
    }


    /// <summary>
    /// 玩家的编号
    /// </summary>
    public int PlayerId
    {
        get
        {
            return playerId;
        }

        set
        {
            playerId = value;
        }
    }
    /// <summary>
    /// 玩家的角色名称
    /// </summary>
    public string PlayerName
    {
        get
        {
            return playerName;
        }

        set
        {
            playerName = value;
        }
    }
    /// <summary>
    /// 玩家的等级
    /// </summary>
    public string PlayArea
    {
        get
        {
            return playArea;
        }

        set
        {
            playArea = value;
        }
    }
 
    /// <summary>
    /// 是否是当前正在玩的玩家
    /// </summary>
    public bool IsPlaying
    {
        get
        {
            return isPlaying;
        }

        set
        {
            isPlaying = value;
        }
    }

    /// <summary>
    /// 登录日期
    /// </summary>
    public DateTime LoginDate
    {
        get
        {
            return loginDate;
        }

        set
        {
            loginDate = value;
        }
    }
    /// <summary>
    /// 用户的序列号
    /// </summary>
    public int SerNo
    {
        get
        {
            return serNo;
        }

        set
        {
            serNo = value;
        }
    }
    /// <summary>
    /// 游戏对象的模型
    /// </summary>
    public string PlayModelName
    {
        get
        {
            return playModelName;
        }

        set
        {
            playModelName = value;
        }
    }

    public string HeadPortrail
    {
        get
        {
            return _headPortrail;
        }

        set
        {
            _headPortrail = value;
        }
    }

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

    /// <summary>
    /// 战斗力
    /// </summary>
    public int Power
    {
        get
        {
            return GameController.GetRequirePlayerPowerByHpAndDamage(this.EnergyMax, this.Damage);
        }

        set
        {
            _power = value;
        }
    }

    public int Exp
    {
        get
        {
            return _exp;
        }

        set
        {
            _exp = value;
        }
    }

    /// <summary>
    /// 经验升级规则
    /// 1-0
    /// 2-0+100 
    /// 3-0+100+110 
    /// 4-0+100+110+120
    /// ...
    /// n- 0+100+.....(100+10(n-2))
    /// 
    /// 公式： (A1+An)*N/2  A1=100  An=(100+10(n-2))   N(个数)=n-1
    /// </summary>
    public int ExpMax
    {
        get
        {
            return GameController.GetRequirePlayerExpByLevel(this.Level);
        }

        set
        {
            _expMax = GameController.GetRequirePlayerExpByLevel(this.Level);
        }
    }

    public int Damage
    {
        get
        {
            return GameController.GetRequirePlayerDamageByLevel(this.Level);
        }

        set
        {
            damage = value;
        }
    }

    public int Diamond
    {
        get
        {
            return _diamond;
        }

        set
        {
            _diamond = value;
        }
    }

    public int Coin
    {
        get
        {
            return _coin;
        }

        set
        {
            _coin = value;
        }
    }

    public int Energy
    {
        get
        {
            return _energy;
        }

        set
        {
            _energy = value;
        }
    }

    public int EnergyMax
    {
        get
        {
            return GameController.GetRequirePlayerHpByLevel(this.Level);
        }

        set
        {
            _energyMax = value;
        }
    }

    public int Toughen
    {
        get
        {
            return _toughen;
        }

        set
        {
            _toughen = value;
        }
    }

    public int ToughenMax
    {
        get
        {
            return _toughenMax;
        }

        set
        {
            _toughenMax = value;
        }
    }
}