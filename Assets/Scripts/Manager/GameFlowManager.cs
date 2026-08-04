using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏状态
/// </summary>
public enum GameState
{
    /// <summary>
    /// 主菜单
    /// </summary>
    Menu,
    /// <summary>
    /// 游戏中
    /// </summary>
    Playing,
    /// <summary>
    /// 游戏结束
    /// </summary>
    Over,
}

/// <summary>
/// 游戏流程管理器
/// </summary>
public class GameFlowManager : MonoBehaviour
{
    public static GameFlowManager instance;

    public BirdControl bird;

    private Action readyEvent;
    private Action playingEvent;
    private Action overEvent;

    private void Awake()
    {
        instance = this;
    }

    private void ChangeState(GameState state)
    {
        switch (state)
        {
            case GameState.Menu:
                EnterReady();
                break;
            case GameState.Playing:
                EnterPlaying();
                break;
            case GameState.Over:
                EnterOver();
                break;
        }
    }
    
    /// <summary>
    /// 进入准备状态
    /// </summary>
    private void EnterReady()
    {
        UIManager.instance.HidePanel<EndPanel>();
        UIManager.instance.ShowPanel<StartPanel>();
    }

    /// <summary>
    /// 进入游戏中状态
    /// </summary>
    private void EnterPlaying()
    {
        UIManager.instance.HidePanel<StartPanel>();
        UIManager.instance.ShowPanel<MidPanel>();
        PipeManager.instance.StartGenerate();
        ScoreManager.instance.ResetScore();
        bird.Rebirth();
    }

    /// <summary>
    /// 进入游戏结束状态
    /// </summary>
    private void EnterOver()
    {
        PipeManager.instance.StopGenerate();
        bird.Dead();
        UIManager.instance.ShowPanel<EndPanel>();
        UIManager.instance.HidePanel<MidPanel>();
        ScoreManager.instance.SetEndScore();
    }

    /// <summary>
    /// 准备游戏
    /// </summary>
    public void ReadyGame()
    {
        ChangeState(GameState.Menu);
    }

    /// <summary>
    /// 开始游戏
    /// </summary>
    public void StartGame()
    {
        ChangeState(GameState.Playing);
    }

    /// <summary>
    /// 游戏结束
    /// </summary>
    public void OverGame()
    {
        ChangeState(GameState.Over);
    }
}
