using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 数据库连接的基类
/// </summary>
public class SqlBase {

    //string conn = "URI=file:" + Application.dataPath + "/PickAndPlaceDatabase.s3db"; //Path to database.
    string conn = "data source=" + Application.dataPath + "/" + "Data/" + "Fairy.db";
    /// <summary>
    /// 获取链接
    /// </summary>
    /// <returns></returns>
    public SqliteConnection  GetSqlCnnection() {
        SqliteConnection con = null;

        try
        {
 
            con = new SqliteConnection(conn);
            con.Open();
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);

        }

        return con;
    }
    /// <summary>
    /// 关闭连接
    /// </summary>
    /// <param name="conn"></param>
    public void CloseConnection(SqliteConnection conn) {
        if (conn != null) {
            conn.Close();
        }
    }

}
