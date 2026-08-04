using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 鸟控制
/// </summary>
public class BirdControl : MonoBehaviour
{
    // 重力加速度
    public float gravity = 10f;
    // 加速程度
    public float rate = 0.5f;
    // 跳跃速度
    public Vector2 upVelocity;
    // 是否死亡
    public bool isDead;
    // 重生坐标
    public Vector2 rebirthPos;
    // 最高坐标
    public Vector2 maxPos;
    // 刚体
    private Rigidbody2D rb;
    // 动画
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Dead();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;

        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
        Fall();
    }

    /// <summary>
    /// 下落
    /// </summary>
    public void Fall()
    {
        rb.velocity += Vector2.down * gravity * Time.deltaTime * rate;
        rb.position = Vector2.Min(rb.position, maxPos);
    }

    /// <summary>
    /// 跳跃
    /// </summary>
    public void Jump()
    {
        MusicManager.instance.PlayFlyEff(1f);
        rb.velocity = upVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 碰到地面死亡
        if (collision.gameObject.CompareTag("Ground")) 
        {
            MusicManager.instance.PlayEff(Eff_Type.Hit);
            GameFlowManager.instance.OverGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 碰到管道死亡
        if (collision.gameObject.CompareTag("Pipe"))
        {
            MusicManager.instance.PlayEff(Eff_Type.Hit);
            GameFlowManager.instance.OverGame();
        }

        // 穿过管道得分
        if (collision.gameObject.CompareTag("BlankPipe"))
        {
            MusicManager.instance.PlayAwardEff(1f);
            ScoreManager.instance.AddScore();
        }
    }

    /// <summary>
    /// 死亡
    /// </summary>
    public void Dead()
    {
        isDead = true;
        anim.SetBool("isDead", isDead);
        rb.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 重生
    /// </summary>
    public void Rebirth()
    {
        if (!isDead) return;
        gameObject.SetActive(true);
        transform.position = rebirthPos;
        isDead = false;
        anim.SetBool("isDead", isDead);
    }
}
