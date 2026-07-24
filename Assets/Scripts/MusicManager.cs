using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 音效类型枚举
public enum Eff_Type
{
    Button,
    Fly,
    Award,
    Hit,
}

/// <summary>
/// 音乐管理器
/// </summary>
public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    // 音效片段
    public List<AudioClip> clips = new List<AudioClip>();
    // 最大音源数量
    public int maxAudioSources = 4;
    // 背景音乐片段
    public AudioClip bgmClip;
    // 场景中所有音源
    private List<AudioSource> audioSources = new List<AudioSource>();
    // 当前音源索引
    private int nowIndex;
    // 背景音源
    private AudioSource bgmSource;

    private void Awake()
    {
        Instance = this;
        PlayBGM();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="type"></param>
    /// <param name="volume"></param>
    public void PlayEff(Eff_Type type,float volume)
    {
        AudioSource audioSource;
        if (audioSources.Count < maxAudioSources)
        {
            GameObject obj = new GameObject();
            audioSource = obj.AddComponent<AudioSource>();
            audioSources.Add(audioSource);
            obj.name = "Eff" + "_" + audioSources.Count;
        }
        else
        {
            audioSource = audioSources[nowIndex];
            nowIndex++;
            if (nowIndex >= maxAudioSources) 
            {
                nowIndex = 0;
            }
        }
        audioSource.Stop();

        AudioClip clip = clips[(int)type];
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.Play();
    }

    /// <summary>
    /// 播放按钮音效
    /// </summary>
    /// <param name="volume"></param>
    public void PlayButtonEff(float volume)
    {
        PlayEff(Eff_Type.Button, volume);
    }

    /// <summary>
    /// 播放振翅音效
    /// </summary>
    /// <param name="volume"></param>
    public void PlayFlyEff(float volume)
    {
        PlayEff(Eff_Type.Fly, volume);
    }

    /// <summary>
    /// 播放得分音效
    /// </summary>
    /// <param name="volume"></param>
    public void PlayAwardEff(float volume)
    {
        PlayEff(Eff_Type.Award, volume);
    }
    
    /// <summary>
    /// 播放撞击音效
    /// </summary>
    /// <param name="volume"></param>
    public void PlayHitEff(float volume)
    {
        PlayEff(Eff_Type.Hit, volume);
    }

    /// <summary>
    /// 播放背景音乐
    /// </summary>
    /// <param name="volume"></param>
    public void PlayBGM(float volume = 1f)
    {
        if (bgmSource == null)
        {
            GameObject obj = new GameObject();
            obj.name = "BGM";
            bgmSource = obj.AddComponent<AudioSource>();
        }
        bgmSource.Stop();
        bgmSource.clip = bgmClip;
        bgmSource.loop = true;
        bgmSource.volume = volume;
        bgmSource.Play();
    }
}
