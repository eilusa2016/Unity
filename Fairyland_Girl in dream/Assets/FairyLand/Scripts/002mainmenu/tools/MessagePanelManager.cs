using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 提示信息的弹窗
/// </summary>
public class MessagePanelManager : MonoBehaviour {

    public static MessagePanelManager _instance;
    private TweenAlpha messagePanel;
    private UILabel messageLabel;
    private void Awake()
    {
        _instance = this;
        messagePanel =GetComponent<TweenAlpha>();
        messageLabel = transform.Find("Sprite/messageLabel").GetComponent<UILabel>();

        messagePanel.onFinished.Add(new EventDelegate(this, "OnTweenAlphFinshed"));
        gameObject.SetActive(false);
    }
    /// <summary>
    /// 设置显示的消息
    /// </summary>
    /// <param name="mess"></param>
    /// <param name="hideTime"></param>
    public void SetMessage(string mess, float hideTime) {
        gameObject.SetActive(true);
        StartCoroutine(ShowPanel(mess,hideTime));
    }
    private bool needHide = false;
    IEnumerator ShowPanel(string mess, float hideTime) {
        needHide = false;
        messagePanel.PlayForward();
        messageLabel.text = mess;
        yield return new WaitForSeconds(hideTime);
        needHide = true;
        messagePanel.PlayReverse();
    }

    /// <summary>
    /// 结束动画后的事件
    /// </summary>
    void OnTweenAlphFinshed() {
        if (needHide) {
            gameObject.SetActive(false);
        }
    }

}
