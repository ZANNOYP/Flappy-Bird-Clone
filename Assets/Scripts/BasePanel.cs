using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 面板基类
/// </summary>
public abstract class BasePanel : MonoBehaviour
{
    // 渐变速度
    public float fadeSpeed = 5f;
    // 是否显示
    private bool isShow;
    // 是否渐显隐
    private bool isFade;

    protected CanvasGroup canvasGroup;

    protected virtual void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    protected void Update()
    {
        if (isFade)
            Fade();
    }

    /// <summary>
    /// 渐显隐
    /// </summary>
    protected void Fade()
    {
        if (isShow && canvasGroup.alpha < 1f)
        {
            canvasGroup.alpha += Time.deltaTime * fadeSpeed;
            if (canvasGroup.alpha >= 1f)
            {
                canvasGroup.alpha = 1f;
                canvasGroup.blocksRaycasts = true;
                canvasGroup.interactable = true;
            }
        }
        if (!isShow && canvasGroup.alpha > 0)
        {
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
            canvasGroup.alpha -= Time.deltaTime * fadeSpeed;
            if (canvasGroup.alpha <= 0)
            {
                canvasGroup.alpha = 0;
                gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// 显示面板
    /// </summary>
    /// <param name="isFade">是否渐显隐</param>
    public virtual void Show(bool isFade = true)
    {
        this.isFade = isFade;
        isShow = true;
        gameObject.SetActive(true);

        if (!isFade)
        {
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;
        }
    }

    /// <summary>
    /// 隐藏面板
    /// </summary>
    /// <param name="isFade">是否渐显隐</param>
    public virtual void Hide(bool isFade = true)
    {
        this.isFade = isFade;
        isShow = false;

        if (!isFade)
        {
            canvasGroup.alpha = 0;
            gameObject.SetActive(false);
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
        }
    }
}
