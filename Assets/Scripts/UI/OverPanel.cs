using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
/// <summary>
/// 结束界面
/// </summary>
public class OverPanel : BasePanel<OverPanel>
{
    // 返回按钮
    public Button btnReturn;
    // 鸟
    public Bird bird;
    // 分数文本
    public TextMeshProUGUI txtScore;
    // 最高分数文本
    public TextMeshProUGUI txtHightestScore;
    // 最高分数
    private int maxScore;

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Init()
    {
        maxScore = PlayerPrefs.GetInt("maxScore", 0);
        btnReturn.onClick.AddListener(() =>
        {
            SFXMgr.Instance.PlaySFX("btnEff", 0.5f);
            // 重置游戏
            GameMgr.Instance.ResetGame();
        });
        // 默认隐藏自己
        HideMe();
    }

    /// <summary>
    /// 更新分数
    /// </summary>
    /// <param name="score"></param>
    public void UpdateScore(int score)
    {
        txtScore.text = score.ToString();
    }

    /// <summary>
    /// 更新最高分数
    /// </summary>
    /// <param name="score"></param>
    public void UpdateHighestScore(int score)
    {
        if (score > maxScore)
        {
            maxScore = score;
            PlayerPrefs.SetInt("maxScore", maxScore);
        }

        txtHightestScore.text = maxScore.ToString();
    }

    /// <summary>
    /// 显示自己
    /// </summary>
    public override void ShowMe()
    {
        // 更新分数
        UpdateScore(int.Parse(GamePanel.Instance.txtScore.text));
        UpdateHighestScore(int.Parse(GamePanel.Instance.txtScore.text));
        base.ShowMe();
    }
}
