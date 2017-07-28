using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 加载场景的进度条
/// </summary>
public class LoadSenceBar : MonoBehaviour {
    public static LoadSenceBar _instance;
    private TweenAlpha alpha;
    private UISlider batBar;
    private UISlider loadBar;

    private AsyncOperation asyInfo = null;
    private bool isLoading = false;
    float loading = 0f;
    float showPercent, countPercent;
    private void Awake()
    {
        _instance = this;
        alpha = GetComponent<TweenAlpha>();
        batBar = transform.Find("batli/Sprite").GetComponent<UISlider>();
        loadBar = transform.Find("sliderbg/loadbar").GetComponent<UISlider>();
    }

    private void Start()
    {
        showPercent = 0;
        countPercent = 0;

        string _scenceName =PlayerPrefs.GetString("_scenceName");
        asyInfo = null;
        LoadScene(_scenceName);
    }

    void LoadScene(string _scenceName) {
        asyInfo = SceneManager.LoadSceneAsync(_scenceName, LoadSceneMode.Single);
        asyInfo.allowSceneActivation = false;
        StartCoroutine(LoadSence(_scenceName));
    }

   
    /// <summary>
    /// 异步加载场景
    /// </summary>
    /// <param name="name"></param>
    IEnumerator LoadSence(string name) {

       
        while (asyInfo.progress < 0.9f && asyInfo.progress != 0) {
            countPercent =asyInfo.progress;
            while (showPercent < countPercent)
            {
                ++showPercent;
                SetLoadPercent(showPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        countPercent = 100f;
        while (showPercent < countPercent)
        {
            ++showPercent;
            SetLoadPercent(showPercent);
            yield return new WaitForEndOfFrame();
        }
        print("asyInfo.progress2=" + asyInfo.progress);
        yield return new WaitForEndOfFrame();
        isLoading = true;
        asyInfo.allowSceneActivation = true;
        //yield return new WaitForEndOfFrame();
    }

    void SetLoadPercent(float showPercent) {

        //print("showPercent / 100f="+ showPercent / 100f);
        batBar.value = showPercent / 100f;
        loadBar.value = showPercent / 100f;
        if (showPercent == 100)
        {
            isLoading = false;
        }
    }
}
