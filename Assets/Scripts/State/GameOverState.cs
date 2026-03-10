using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : IGameState
{
    private PipeBootstrap pipeBootstrap;

    public GameOverState(PipeBootstrap pipeBootstrap)
    {
        this.pipeBootstrap = pipeBootstrap;
    }

    public void Enter()
    {
        OverPanel.Instance.ShowMe();
        pipeBootstrap.StopPipe();
    }

    public void Exit()
    {
        OverPanel.Instance.HideMe();
    }
}
