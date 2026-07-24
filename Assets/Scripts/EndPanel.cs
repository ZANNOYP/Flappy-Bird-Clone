using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 结束面板
/// </summary>
public class EndPanel : MonoBehaviour
{
    public static EndPanel Instance;
    // 是否显示
    public bool isShow;
    // 是否渐显隐
    public bool isFade;
    // 渐变速度
    public float speed = 5f;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        Instance = this;
        canvasGroup = GetComponent<CanvasGroup>();
        Hide(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFade) 
            FadeOut();
    }

    /// <summary>
    /// 渐显隐
    /// </summary>
    public void FadeOut()
    {
        if (isShow && canvasGroup.alpha < 1f) 
        {
            canvasGroup.alpha += Time.deltaTime * speed;
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
            canvasGroup.alpha -= Time.deltaTime * speed;
            if (canvasGroup.alpha <= 0)
            {
                canvasGroup.alpha = 0;
            }
        }
    }

    /// <summary>
    /// 显示面板
    /// </summary>
    /// <param name="isFade"></param>
    public void Show(bool isFade = true)
    {
        this.isFade = isFade;
        isShow = true;

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
    /// <param name="isFade"></param>
    public void Hide(bool isFade = true)
    {
        this.isFade = isFade;
        isShow = false;

        if (!isFade)
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
        }
    }
}
