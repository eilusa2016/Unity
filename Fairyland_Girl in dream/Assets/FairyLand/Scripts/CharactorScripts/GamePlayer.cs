using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏玩家的类
/// </summary>
public class GamePlayer : MonoBehaviour {

    private PlayerProperty playerProperty;

    public PlayerProperty setProperty(PlayerProperty p) {
        this.playerProperty = p;
        return p;

    }
    /// <summary>
    /// 获取玩家的属性
    /// </summary>
    /// <returns></returns>
    public PlayerProperty getProperty() {
          return this.playerProperty;
    }
  

}
