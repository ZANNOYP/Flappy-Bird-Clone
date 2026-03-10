using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBootstrap : MonoBehaviour
{
    [SerializeField]
    private UnityRepeatTimer timer;
    [SerializeField]
    private UnityPipeFactory factory;
    [SerializeField]
    // 管道生成间隔时间
    private float generateTime = 2f;
    [SerializeField]
    // 管道Y坐标最大值
    private float upYpos = 3.5f;
    [SerializeField]
    // 管道Y坐标最小值
    private float downYpos = 0.5f;
    [SerializeField]
    // 鸟
    private Bird bird;

    [SerializeField]
    private GameObject pipePrefab;

    [SerializeField]
    private float defaultX;

    private PipeGameLogic pipeLogic;


    private void Awake()
    {
        pipeLogic = new PipeGameLogic(timer, factory, generateTime, bird, pipePrefab);
        factory.Init(downYpos, upYpos, defaultX, pipePrefab);
    }

    public void StartPipe()
    {
        pipeLogic.StartGeneratePipe();
    }

    public void StopPipe()
    {
        pipeLogic?.StopGeneratePipe();
    }

    public void ClearPipe()
    {
        pipeLogic.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        pipeLogic.Tick();
    }
}
