using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingState : IGameState
{
    private IBird bird;
    private PipeBootstrap pipeBootstrap;

    public PlayingState(IBird bird, PipeBootstrap pipeBootstrap)
    {
        this.bird = bird;
        this.pipeBootstrap = pipeBootstrap;
    }

    public void Enter()
    {
        // 重置分数
        GamePanel.Instance.UpdateScore(true);
        // 显示游戏面板
        GamePanel.Instance.ShowMe();
        // 鸟开始飞
        bird.StartFly();
        // 管道管理器开始生成管道
        pipeBootstrap.StartPipe();
    }

    public void Exit()
    {
        GamePanel.Instance.HideMe();
    }
}
