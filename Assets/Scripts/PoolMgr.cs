using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 对象池
/// </summary>
public class PoolMgr : BaseSingleton<PoolMgr>
{
    private Dictionary<GameObject,Stack<GameObject>> poolDic = new Dictionary<GameObject,Stack<GameObject>>();

    /// <summary>
    /// 放
    /// </summary>
    /// <param name="obj"></param>
    public void Push(GameObject prefab, GameObject obj)
    {
        if (!poolDic.TryGetValue(prefab, out var pool))
        {
            pool = new Stack<GameObject>();
            poolDic[prefab] = pool;
        }
        obj.SetActive(false);
        pool.Push(obj);
    }

    /// <summary>
    /// 取
    /// </summary>
    /// <param name="prefab"></param>
    /// <returns></returns>
    public GameObject Pop(GameObject prefab, Action<GameObject> onGet = null)
    {
        GameObject obj;
        if (poolDic.TryGetValue(prefab, out var pool) && pool.Count > 0) 
        {
            obj = pool.Pop();
        }
        else
        {
            obj = GameObject.Instantiate(prefab);
            obj.name = prefab.name;
        }
        onGet?.Invoke(obj);
        obj.SetActive(true);
        return obj;
    }
}
