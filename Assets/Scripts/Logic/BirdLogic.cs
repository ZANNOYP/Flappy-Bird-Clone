using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdLogic
{
    private readonly IInputService inputService;
    private readonly IBird bird;

    public BirdLogic(IInputService inputService, IBird bird)
    {
        this.inputService = inputService;
        this.bird = bird;
    }

    public void Tick()
    {
        // 游戏在进行状态 不移动
        if (GameMgr.Instance.State != GameState.Playing)
            return;
        // 若鼠标左键按下 则直接改变鸟垂直方向速度为反方向往上
        if (inputService.IsJumpPressed()) 
        {
            bird.Jump();
        }
        bird.Fall();
    }
}
