using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/// <summary>
/// 游戏界面
/// </summary>
public class GamePanel : BasePanel<GamePanel>
{
    // 分数文本
    public TextMeshProUGUI txtScore;
    // 分数
    private int score;

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Init()
    {
        // 重置分数
        UpdateScore(true);
        HideMe();
    }

    /// <summary>
    /// 更新分数
    /// </summary>
    /// <param name="isReset">重置分数</param>
    public void UpdateScore(bool isReset = false)
    {
        if (isReset)
        {
            score = 0;
        }
        else
        {
            score += 1;
        }
        txtScore.text = score.ToString();
    }

}
