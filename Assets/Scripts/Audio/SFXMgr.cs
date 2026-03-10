using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXMgr : MonoBehaviour
{
    private static SFXMgr instance;
    public static SFXMgr Instance => instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject sfxPrefab;

    public void PlaySFX(string effName,float volume)
    {
        AudioClip clip = Resources.Load<AudioClip>(effName);
        GameObject obj = PoolMgr.Instance.Pop(sfxPrefab);
        AudioSource audioSource = obj.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = obj.AddComponent<AudioSource>();
        }
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.Play();
        StartCoroutine(ReleaseAfterPlay(obj, clip.length));
    }

    private IEnumerator ReleaseAfterPlay(GameObject obj, float length)
    {
        yield return new WaitForSeconds(length);
        AudioSource audioSource = obj.GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.clip = null;
        }
        PoolMgr.Instance.Push(sfxPrefab, obj);
    }
}
