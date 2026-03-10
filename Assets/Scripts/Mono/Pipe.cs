using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 管道
/// </summary>
public class Pipe : MonoBehaviour, IPipe
{
    // 移动速度
    public float moveSpeed = 1.0f;
    public float destroyX = -3f;
    // 鸟
    private Bird bird;

    public bool IsDead { get; private set; }

    /// <summary>
    /// 初始化鸟
    /// </summary>
    /// <param name="bird"></param>
    public void Init(Bird bird)
    {
        this.bird = bird;
    }

    public void SetPos(float x, float y)
    {
        Vector3 pos = new Vector3(x, y, 0);
        transform.position = pos;
        IsDead = false;
    }

    public void Move()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    public void Release()
    {
        // 如果管道X坐标到达-3 摧毁管道 并移除容器
        if (transform.position.x <= destroyX)
        {
            IsDead = true;
        }
    }

    public void RealRelease(GameObject prefab)
    {
        PoolMgr.Instance.Push(prefab, gameObject);
    }
}
