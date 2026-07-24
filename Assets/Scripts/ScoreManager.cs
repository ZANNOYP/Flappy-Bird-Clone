using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/// <summary>
/// 分数管理器
/// </summary>
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    // 分数文本
    public TextMeshProUGUI textScore;
    // 结束分数文本
    public TextMeshProUGUI textEndScore;
    // 结束最高分数文本
    public TextMeshProUGUI textEndHighestScore;
    // 当前分数
    private int nowScore;
    // 最高分数
    private int highestScore;

    private void Awake()
    {
        Instance = this;
        highestScore = PlayerPrefs.GetInt("HighestScore", 0);
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
    /// 加分
    /// </summary>
    public void AddScore()
    {
        nowScore++;
        RefreshUI();
    }

    /// <summary>
    /// 刷新UI
    /// </summary>
    public void RefreshUI()
    {
        textScore.text = nowScore.ToString();
    }

    /// <summary>
    /// 重置分数
    /// </summary>
    public void ResetScore()
    {
        nowScore = 0;
        RefreshUI();
    }

    /// <summary>
    /// 设置最终分数
    /// </summary>
    public void SetEndScore()
    {
        textEndScore.text = nowScore.ToString();
        highestScore = highestScore >= nowScore ? highestScore : nowScore;
        if (nowScore == highestScore) 
            PlayerPrefs.SetInt("HighestScore", highestScore);
        textEndHighestScore.text = highestScore.ToString();
    }
}
