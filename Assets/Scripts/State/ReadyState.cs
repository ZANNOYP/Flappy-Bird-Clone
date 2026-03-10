using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyState : IGameState
{
    private IBird bird;
    private PipeBootstrap pipeBootstrap;

    public ReadyState(IBird bird, PipeBootstrap pipeBootstrap)
    {
        this.bird = bird;
        this.pipeBootstrap = pipeBootstrap;
    }

    public void Enter()
    {
        BeginPanel.Instance.ShowMe();
        // 鸟初始化
        bird.Init();
        // 删除管道
        pipeBootstrap.ClearPipe();
    }

    public void Exit()
    {
        BeginPanel.Instance.HideMe();
    }
}
