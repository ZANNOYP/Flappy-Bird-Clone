using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 鸟
/// </summary>
public class Bird : MonoBehaviour,IBird
{
    // 鼠标按下鸟垂直方向的速度
    public float mouseButtonDownSpeed = -5f;
    // 鸟垂直方向初始速度
    private float downSpeed;
    // 鸟初始位置
    [HideInInspector]
    public Vector2 beginPos;
    // 鸟的死亡事件
    public Action onDead;
    // 鸟飞行的y轴上限
    public float clampMaxY = 3f;
    // Start is called before the first frame update
    void Start()
    {
        // 记录初始位置
        beginPos = transform.position;
        // 初始化速度、位置、显隐
        Init();
    }

    /// <summary>
    /// 初始化鸟
    /// </summary>
    public void Init()
    {
        // 速度
        downSpeed = 0f;
        // 位置
        transform.position = beginPos;
        // 显隐
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 鸟开始飞行
    /// </summary>
    public void StartFly()
    {
        // 显隐
        gameObject.SetActive(true);
    }

    public void Fall()
    {
        // 每帧改变鸟垂直方向速度
        downSpeed = downSpeed + 10 * Time.deltaTime;
        // 得到鸟目标位置 限制y轴上限
        Vector3 targetPos = transform.position + Vector3.down * downSpeed * Time.deltaTime;
        targetPos.y = Mathf.Min(targetPos.y, clampMaxY);

        transform.position = targetPos;
    }

    public void Jump()
    {
        SFXMgr.Instance.PlaySFX("flyEff", 1.0f);
        downSpeed = mouseButtonDownSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 碰到管道结束游戏
        if (collision.gameObject.tag == "Pipe")
        {
            SFXMgr.Instance.PlaySFX("hitEff", 0.5f);
            onDead?.Invoke();
        }
        // 碰到地面结束游戏
        if (collision.gameObject.tag == "Ground")
        {
            SFXMgr.Instance.PlaySFX("hitEff", 0.5f);
            downSpeed = 0;
            onDead?.Invoke();
        }
        // 进入计分空白区域
        if (collision.gameObject.tag == "BlankPipe")
        {
            // 游戏进行中 则计分
            if (GameMgr.Instance.State == GameState.Playing)
            {
                SFXMgr.Instance.PlaySFX("awardEff", 0.5f);
                GamePanel.Instance.UpdateScore();
            }
        }
    }
}
