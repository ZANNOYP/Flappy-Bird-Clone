using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 面板基类
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class BasePanel<T> : MonoBehaviour where T:class
{
    private static T instance;
    public static T Instance => instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this as T;
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    /// <summary>
    /// 初始化
    /// </summary>
    protected abstract void Init();

    /// <summary>
    /// 显示面板
    /// </summary>
    public virtual void ShowMe()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// 隐藏面板
    /// </summary>
    public virtual void HideMe()
    {
        gameObject.SetActive(false);
    }
}
