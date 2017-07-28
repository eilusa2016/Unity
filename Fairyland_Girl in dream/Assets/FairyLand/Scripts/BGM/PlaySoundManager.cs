using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 背景音乐
/// 一起其他游戏音乐的管理工具组件
/// </summary>
/// 
[RequireComponent(typeof(AudioSource))]
public class PlaySoundManager : MonoBehaviour {

    public AudioSource BGM;
    public AudioSource clipSource;
    public static PlaySoundManager _instance;
    //音乐的集合
    private Dictionary<string, AudioClip> audios = new Dictionary<string, AudioClip>();
    public AudioClip[] audioClips;

    private void Awake()
    {
        _instance = this;
        InstanceAudios();
    }

    void InstanceAudios() {
        if (audioClips == null) {
            return;
        }
        foreach (AudioClip audio in audioClips) {
            audios.Add(audio.name, audio);
        }
    }

    public void PlayMusicByName(string m_name) {
        if (clipSource == null) {
            Debug.LogError("AudioSource clipSource==null");
            return;
        }
        AudioClip clip = null;
        if (audios.TryGetValue(m_name, out clip)) {
            clipSource.PlayOneShot(clip);
        }


    }

    public void PlayMusicByName(string m_name, AudioSource aSource)
    {
        if (aSource == null)
        {
            Debug.LogError("AudioSource clipSource==null");
            return;
        }
        AudioClip clip = null;
        if (audios.TryGetValue(m_name, out clip))
        {
            aSource.PlayOneShot(clip);
        }
    }


     


}
