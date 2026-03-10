using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 管道管理器
/// </summary>
public class PipeMgr
{
    // 管道容器
    private readonly List<IPipe> pipes = new List<IPipe>();

    private GameObject prefab;

    public PipeMgr(GameObject prefab)
    {
        this.prefab = prefab;
    }

    public void Add(IPipe pipe)
    {
        pipes.Add(pipe);
    }

    public void Tick()
    {
        for (int i = pipes.Count-1; i >= 0; i--)
        {
            var pipe = pipes[i];
            if (pipe == null || pipe.IsDead)
            {
                if (pipe != null) 
                    pipe.RealRelease(prefab);
                pipes.Remove(pipe);
                continue;
            }
            pipe.Move();
            pipe.Release();
        }
    }

    /// <summary>
    /// 删除所有管道
    /// </summary>
    public void Clear()
    {
        // 遍历管道容器 删除
        foreach (var pipe in pipes)
        {
            if (pipe != null || !pipe.IsDead) 
                pipe.RealRelease(prefab);
        }
        pipes.Clear();
    }

    

}
