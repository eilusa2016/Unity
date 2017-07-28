using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 右上角的工具栏
/// </summary>
public class TopRightBar : MonoBehaviour {


    private UILabel coinLabel;
    private UILabel diamondLabel;
    private UIButton addCoin;
    private UIButton addDiamond;
    private PlayerInformation playerInfo;



    private void Awake()
    {
        coinLabel = transform.Find("Play-GoldsBar/Label-golds").GetComponent<UILabel>();
        diamondLabel = transform.Find("Play-DiamondsBar/Label-dimonds").GetComponent<UILabel>();

        addCoin= transform.Find("Play-GoldsBar/player-btn-addgolds").GetComponent<UIButton>();
        addDiamond = transform.Find("Play-DiamondsBar/player-btn-adddiamond").GetComponent<UIButton>();
        playerInfo = PlayerInformation._instance;
        PlayerInformation._instance.OnPlayInfoChanged += OnPlayerInfoChanged;
    }
    /// <summary>
    /// 当值发生变化的时候
    /// 会被触发
    /// </summary>
    /// <param name="infoType"></param>
    void OnPlayerInfoChanged(PlayerInfoType infoType)
    {
        if (infoType == PlayerInfoType.All || infoType == PlayerInfoType.Coin || infoType == PlayerInfoType.Diamond)
        {
            //需要更新
            upDateShow();
        }

    }
    /// <summary>
    /// 更新显示
    /// </summary>
    void upDateShow()
    {
        InitBarInfomations();
    }
    /// <summary>
    /// 初始化显示
    /// </summary>
    void InitBarInfomations()
    {

        coinLabel.text = playerInfo.Coin.ToString();
        diamondLabel.text=playerInfo.Diamond.ToString();
        //addCoin.onClick += OnAddCoins();
        //addDiamond.onClick += null;


    }

    private void OnDestroy()
    {
        //取消注册
        PlayerInformation._instance.OnPlayInfoChanged -= OnPlayerInfoChanged;
    }


}
