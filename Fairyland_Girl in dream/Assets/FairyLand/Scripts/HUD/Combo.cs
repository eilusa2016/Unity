using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 连击的效果
/// </summary>
public class Combo : MonoBehaviour {

    public static Combo _combo;
    private UILabel HUDText;
    public float comboTime = 2f;
    float comboTimer = 0;
    float comboCount = 0;
    private void Awake()
    {
        _combo = this;
        HUDText = transform.Find("HUDText").GetComponent<UILabel>();
        this.gameObject.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
        comboTimer -= Time.deltaTime;
        if (comboTimer <= 0) {
            this.gameObject.SetActive(false);
            comboCount = 0;
        }

    }

    /// <summary>
    /// 增加连击
    /// </summary>
    public void AddCombo() {
        this.gameObject.SetActive(true);
        comboTimer = comboTime;
        comboCount++;
        HUDText.text = comboCount.ToString();
        transform.localScale = Vector3.one;
        iTween.ScaleTo(this.gameObject, new Vector3(1.2f, 1.2f, 1.2f), 0.1f);
        iTween.ShakePosition(this.gameObject,new Vector3(0.3f,0.3f,0.3f),0.2f);
       
    }

}
