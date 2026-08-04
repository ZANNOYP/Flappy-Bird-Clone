using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 开始游戏按钮
/// </summary>
public class StartButton : MonoBehaviour
{
    /// <summary>
    /// 游戏开始
    /// </summary>
    public void GameStart()
    {
        MusicManager.instance.PlayEff(Eff_Type.Button);
        GameFlowManager.instance.StartGame();
    }
}
