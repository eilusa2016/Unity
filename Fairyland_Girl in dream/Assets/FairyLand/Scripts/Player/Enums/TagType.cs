using System;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 标签的类型
/// </summary>
public enum TagType  {
    /// <summary>
    /// 未知的标签
    /// </summary>
    Untagged,
    /// <summary>
    /// 玩家标签
    /// </summary>
    Player,
    /// <summary>
    /// 怪物敌人
    /// </summary>
    Monster,
    /// <summary>
    /// NPC标签
    /// </summary>
    NPC,
    /// <summary>
    /// 刀（特指）标签
    /// </summary>
    katana,
    /// <summary>
    /// 武器标签
    /// </summary>
    Weapon,
    /// <summary>
    /// 火标签
    /// </summary>
    Fire,
    /// <summary>
    /// 地面标签
    /// </summary>
    Terrain,
    /// <summary>
    /// 副本标签
    /// </summary>
    TransScripts,
    /// <summary>
    /// 副本的boss标签
    /// </summary>
    Boss,
    /// <summary>
    /// 魔法标签
    /// </summary>
    Magic,
    /// <summary>
    /// 技能
    /// </summary>
    Skill,
    /// <summary>
    /// 特效（这个其实不用）
    /// </summary>
    Effect


}
/// <summary>
/// 标签的工具类
/// </summary>
public class TagUtils {

    public static TagType GetTagType(string typeName)
    {
        TagType type = 0;
        try {
            type = (TagType)Enum.Parse(typeof(TagType), typeName, false);
        } catch {
            type = 0;
        }
       
        return type;
    }


}


