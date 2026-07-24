using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 管道控制
/// </summary>
public class PipeControl : MonoBehaviour
{
    // 上管道
    public GameObject pipeUp;
    // 下管道
    public GameObject pipeDown;
    // 刚体
    private Rigidbody2D rb;
    // 移速
    private float moveSpeed;
    // 可到达最左X坐标
    private float leftXPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 到达最远处停止移动
        if (transform.position.x <= leftXPos)
        {
            StopMove();
        }
    }

    /// <summary>
    /// 开始移动
    /// </summary>
    public void Move()
    {
        rb.velocity = Vector2.left * moveSpeed;
    }

    /// <summary>
    /// 停止移动
    /// </summary>
    public void StopMove()
    {
        rb.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 设置位置
    /// </summary>
    /// <param name="pos"></param>
    public void SetPos(Vector2 pos)
    {
        transform.position = pos;
    }

    /// <summary>
    /// 设置上下管道位置
    /// </summary>
    /// <param name="posUp"></param>
    /// <param name="posDown"></param>
    public void SetChildPos(Vector2 posUp, Vector2 posDown)
    {
        pipeUp.transform.localPosition = posUp;
        pipeDown.transform.localPosition = posDown;
    }

    /// <summary>
    /// 设置移速
    /// </summary>
    /// <param name="moveSpeed"></param>
    public void SetSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    /// <summary>
    /// 设置最左X坐标
    /// </summary>
    /// <param name="leftXPos"></param>
    public void SetLeftXPos(float leftXPos)
    {
        this.leftXPos = leftXPos;
    }
}
