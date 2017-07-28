using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 控制游戏的一些工具
/// </summary>
public class GameController  {

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
    /// <param name="Level">等级</param>
    /// <returns>返回需要的经验值</returns>
    public static int   GetRequirePlayerExpByLevel(int Level) {
        int exp = 0;
        int N = Level - 1;
        int A1 = 100;
        int An = A1 + (A1 / 10) * (Level - 2);
        exp = (A1 + An) * N / 2;
        return exp;
    }


    /// <summary>
    /// 	Hp=level*100
    /// </summary>
    /// <param name="Level"></param>
    /// <returns></returns>
    public static int GetRequirePlayerHpByLevel(int Level)
    {
        if (Level < 0) {
            Level = 1;
        }
       
        return Level*100;
    }

    /// <summary>
    /// 根据等级获得s伤害值
    /// </summary>
    /// <param name="Level"></param>
    /// <returns></returns>
    public static int GetRequirePlayerDamageByLevel(int Level)
    {
        if (Level < 0)
        {
            Level = 1;
        }

        return Level * 50;
    }


    /// <summary>
    ///战斗力	Power = Hp+Damage
    /// </summary>
    /// <param name="hp"></param>
    /// <param name="damage"></param>
    /// <returns></returns>
    public static int GetRequirePlayerPowerByHpAndDamage(int hp,int damage)
    {
       

        return hp+ damage;
    }



    public static float ParseFloat(string str)
    {
        float num = 0f;
        try
        {
            num = float.Parse(str);
        }
        catch (Exception)
        {
            num = 0f;


        }

        return num;
    }

    public static int ParseInt(string str)
    {
        int num = 0;
        try
        {
            num = int.Parse(str);
        }
        catch (Exception)
        {
            num = 0;


        }

        return num;
    }

    /// <summary>
    /// 转换为物品类型
    /// </summary>
    /// <param name="typeName"></param>
    /// <returns></returns>
    public static ItemType GetItemType(string typeName)
    {
        ItemType type = 0;
        if (typeName == null|| typeName.Trim()=="") {
            return type;
        }
        try
        {
            type = (ItemType)Enum.Parse(typeof(ItemType), typeName, false);
        }
        catch (Exception e)
        {
            type = ItemType.Equip;
            Debug.LogError("typeName="+ typeName + " ,GetItemType(string typeName)物品类型转换失败;=" + GetLineNum());
        }
        return type;
    }
    /// <summary>
    /// 装备类型转换
    /// </summary>
    /// <param name="typeName"></param>
    /// <returns></returns>
    public static EquipType GetEquipType(string typeName)
    {
        EquipType type = 0;
        if (typeName == null || typeName.Trim() == "")
        {
            return type;
        }
        try
        {
            type = (EquipType)Enum.Parse(typeof(EquipType), typeName, false);
        }
        catch (Exception e)
        {
            type = EquipType.Helm;
            Debug.LogError("typeName="+ typeName + " ,GetEquipType(string typeName)装备类型转换失败,=" + GetLineNum());
        }
        return type;
    }

    /// <summary>
    /// 作用类型的转换
    /// </summary>
    /// <param name="typeName"></param>
    /// <returns></returns>
    public static PlayerInfoType GetPlayerInfoType(string typeName)
    {
        PlayerInfoType type = 0;
        if (typeName == null || typeName.Trim() == "")
        {
            return type;
        }
        try
        {
            type = (PlayerInfoType)Enum.Parse(typeof(PlayerInfoType), typeName, false);
        }
        catch (Exception e)
        {
            Debug.LogError("typeName=" + typeName + " ;\n " + GetCurSourceFileName() + ",GetPlayerInfoType(string typeName)作用类型转换失败,=" + GetLineNum());
        }
        return type;
    }

    /// <summary>
    /// 转换任务类型
    /// </summary>
    /// <param name="typeName"></param>
    /// <returns></returns>
    public static TaskType GetTaskType(string typeName) {
        TaskType type = 0;
        if (typeName == null || typeName.Trim() == "")
        {
            return type;
        }
        try
        {
            type = (TaskType)Enum.Parse(typeof(TaskType), typeName, false);
        }
        catch {

            Debug.LogError("typeName=" + typeName + " ;\n " + GetCurSourceFileName() + ",GetTaskType(string typeName)作用类型转换失败,=" + GetLineNum());
        }

        return type;
    }



    /// </summary>
    /// 取得当前源码的哪一行
    /// </summary>
    /// <returns></returns>
    public static int GetLineNum()
    {
        System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(1, true);
        return st.GetFrame(0).GetFileLineNumber();
    }

    /// <summary>
    /// 取当前源码的源文件名
    /// </summary>
    /// <returns></returns>
    public static string GetCurSourceFileName()
    {
        System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(1, true);
        return st.GetFrame(0).GetFileName();
    }

    public static bool isDebug = false;//发布的时候不想看日志  可以直接看着了
    /// <summary>
    /// 记录日志  
    /// 还是错误日志
    /// </summary>
    /// <param name="mess"></param>
    /// <param name="isError"></param>
    public static void DebugLog(string mess,bool isError) {
        if (!isDebug) {
            return;
        }
        if (isError)
        {
            Debug.LogError(mess);
        }
        else {
            Debug.Log(mess);
        }
        
    }
    /// <summary>
    /// 角色类型
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static RoleType GetRoleType(string type) {
        RoleType rtype=0;
        switch (type) {
            case "Warrior":
                rtype = RoleType.Saber;
                break;
            case "FemaleAssassin":
                rtype = RoleType.Assassin;
                break;
            case "Saber":
                rtype = RoleType.Saber;
                break;
            case "Archer":
                rtype = RoleType.Archer;
                break;
            case "Lancer":
                rtype = RoleType.Lancer;
                break;
            case "Rider":
                rtype = RoleType.Rider;
                break;
            case "Caster":
                rtype = RoleType.Caster;
                break;
            case "Assassin":
                rtype = RoleType.Assassin;
                break;
            case "Berserker":
                rtype = RoleType.Berserker;
                break;
        }

        return rtype;
    }

    /// <summary>
    /// 技能类型
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static SkillType GetSkillType(string type) {
        SkillType t=0;
        switch (type) {
            case "Basic":
                t = SkillType.Basic;
                break;
            case "Skill":
                t = SkillType.Skill;
                break;
            case "Magic":
                t = SkillType.Magic;
                break;
        }

        return t;

    }
    /// <summary>
    /// 得到技能的位置
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static SkillPosType GetSkillPosType(string type) {
        SkillPosType t = 0;
        switch (type) {
            case "Basic":
                t = SkillPosType.Basic;
                break;
            case "One":
                t = SkillPosType.Magic1;
                break;
            case "Two":
                t = SkillPosType.Magic2;
                break;
            case "Three":
                t = SkillPosType.Magic3;
                break;
        }

        return t;
    }

}
