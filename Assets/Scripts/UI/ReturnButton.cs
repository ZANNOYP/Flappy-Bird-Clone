using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 返回按钮
/// </summary>
public class ReturnButton : MonoBehaviour
{
    /// <summary>
    /// 准备游戏
    /// </summary>
    public void GameReady()
    {
        MusicManager.instance.PlayEff(Eff_Type.Button);
        GameFlowManager.instance.ReadyGame();
    }
}
