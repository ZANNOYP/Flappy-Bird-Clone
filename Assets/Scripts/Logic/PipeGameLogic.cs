using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGameLogic
{
    private readonly IRepeatTimer timer;
    private readonly IPipeFactory pipeFactory;
    // 管道生成间隔时间
    private readonly float generateTime;
    // 鸟
    private readonly Bird bird;

    private PipeMgr pipeMgr;

    public PipeGameLogic(IRepeatTimer timer, IPipeFactory pipeFactory, float generateTime, Bird bird, GameObject pipePrefab)
    {
        this.timer = timer;
        this.pipeFactory = pipeFactory;
        this.generateTime = generateTime;
        this.bird = bird;
        this.pipeMgr = new PipeMgr(pipePrefab);
    }

    public void Tick()
    {
        // 游戏在进行状态 不移动、不删除
        if (GameMgr.Instance.State != GameState.Playing)
            return;
        pipeMgr.Tick();
    }
    /// <summary>
    /// 开始生成管道
    /// </summary>
    public void StartGeneratePipe()
    {
        timer.StartRepeat(generateTime, () => GameMgr.Instance.State == GameState.Playing, GenerateOnce);
    }

    public void StopGeneratePipe()
    {
        timer.StopRepeat();
    }

    public void Clear()
    {
        pipeMgr.Clear();
    }

    private void GenerateOnce()
    {
        IPipe pipe = pipeFactory.Create();
        pipe.Init(bird);
        pipeMgr.Add(pipe);
    }
}
