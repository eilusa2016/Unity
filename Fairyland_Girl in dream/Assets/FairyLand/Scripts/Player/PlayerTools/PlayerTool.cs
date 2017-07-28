using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


/// <summary>
/// 玩家的工具类
/// 用于存储玩家信息
/// 以及其他的简单读写操作
/// </summary>
public class PlayerTool {

    static object lockThis = new object();
    private static  PlayerTool tool;
    private static string USERLIST= "USERLIST";
    private PlayerTool() {
        
      
    }




    /// <summary>
    /// 得到工具
    /// </summary>
    /// <returns></returns>
    public static PlayerTool getInstance() {
        if (tool == null) {
            lock (lockThis) {
                tool = new PlayerTool();
            }
        }
        return tool;
    }


    
    private List<PlayerProperty> gamePlayers;
    private PlayerProperty player;
    static string folderName = Application.dataPath + "//" + "Data";
    string dataName = "FairyLand.data";
    /// <summary>
    /// 得到当前正在游戏的玩家
    /// </summary>
    /// <returns></returns>
    public PlayerProperty getPlayingGamePlayer() {
        gamePlayers = getGamePlayers();
        player = finPlayerByState(true, gamePlayers);
        return player;
    }


    public  List<PlayerProperty> getGamePlayers()
    {
        #region//oldfile
        //string filePath = folderName + "//" + dataName;
        //DirectoryInfo info = null;
        //if (!hasDataFolder()) {
        //    info=createDataFolder();
        //}
        //FileStream fs = new FileStream(filePath,FileMode.OpenOrCreate);
        //BinaryFormatter bf = new BinaryFormatter();
        //if (fs == null)
        //{
        //    return null;
        //}
        //else {
        //    if (fs.Length > 0) {
        //        gamePlayers = bf.Deserialize(fs) as List<PlayerProperty>;
        //    }

        //}
        //fs.Close();
        #endregion
        String jsonList=PlayerPrefs.GetString(PlayerTool.USERLIST);

        List < PlayerProperty > list = JsonUtility.FromJson<List<PlayerProperty>>(jsonList);
        if (list != null) {
            gamePlayers =list;
        }
       
        return gamePlayers;
    }

    public bool SaveGamePlayers(List<PlayerProperty>  list) {
      
        if (list==null) {
            return false;
        }
        if (list.Count<=0)
        {
            return false;
        }
        //string filePath = folderName + "//" + dataName;
        ////序列化集合
        //FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);   //定义一个文件流
        //BinaryFormatter bf = new BinaryFormatter();     //二进制方式
        // bf.Serialize(fs, list);         //序列化保存配置文件对象list
        // fs.Seek(0, SeekOrigin.Begin);
       
        String userList=JsonUtility.ToJson(list);
        PlayerPrefs.SetString(PlayerTool.USERLIST, userList);

        return true;
    }

    public void AddGamePlayer(PlayerProperty pl) {
        gamePlayers = getGamePlayers();
        gamePlayers=(gamePlayers == null) ? new List<PlayerProperty>() : gamePlayers;
        if (pl != null)
            gamePlayers.Add(pl);
      
        SaveGamePlayers(gamePlayers);
    }

    public void UpdateGamePlayer(GamePlayer pl, bool status, DateTime time)
    {
        foreach (PlayerProperty player in gamePlayers)
        {
            if (pl.getProperty().Equals(player))
            {
                //是同一个
                player.IsPlaying = status;
                player.PlayerName = pl.getProperty().PlayerName;
                player.Energy = pl.getProperty().Energy;
                player.Level = pl.getProperty().Level;
                player.Toughen = pl.getProperty().Toughen;
                player.PlayArea = pl.getProperty().PlayArea;
                player.LoginDate = time;
                break;
            }
        }
        
        SaveGamePlayers(gamePlayers);
    }
 



    public PlayerProperty finPlayerByState(bool state,List<PlayerProperty> list) {
        if (list == null) {
            return player;
        }
        foreach (PlayerProperty pl in list) {

            if (pl.IsPlaying == state) {
                player = pl;
                break;
            }
        }
        return player;
    }

    public PlayerProperty finPlayerByName(string pName)
    {
        PlayerProperty ppl = null;
        if (gamePlayers == null)
        {
            return ppl;
        }
        foreach (PlayerProperty pl in gamePlayers)
        {

            if (pl.PlayerName == pName)
            {
                ppl = pl;
                break;
            }
        }
        return ppl;
    }

    public bool hasDataFolder() {
       return  Directory.Exists(folderName);
    }

    public DirectoryInfo createDataFolder() {
        DirectoryInfo info=Directory.CreateDirectory(folderName);
        return info;
    }



}
