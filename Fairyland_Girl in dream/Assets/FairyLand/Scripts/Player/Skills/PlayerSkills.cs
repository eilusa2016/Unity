using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 玩家所拥有的技能
/// </summary>
public class PlayerSkills {
    
    private int _playerID;
    private List<Skill> _gamerSkills;

    #region 封装字段
    public int PlayerID
    {
        get
        {
            return _playerID;
        }

        set
        {
            _playerID = value;
        }
    }

    public List<Skill> GamerSkills
    {
        get
        {
            return _gamerSkills;
        }

        set
        {
            _gamerSkills = value;
        }
    }


    #endregion
}
