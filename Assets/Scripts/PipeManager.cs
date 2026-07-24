using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 管道管理器
/// </summary>
public class PipeManager : MonoBehaviour
{
    public static PipeManager Instance;

    // 管道Y坐标范围
    public float minY;
    public float maxY;
    // 管道起始X坐标
    public float startXPos;
    // 管道预设体
    public GameObject pipePrefab;
    // 上下管道Y坐标列表
    public List<Vector2> upPoss;
    public List<Vector2> downPoss;
    // 管道移速
    public float moveSpeed;
    // 最左X坐标
    public float leftXPos;
    // 管道生成间隔
    public float generateInterval = 1f;
    // 记录已生成管道
    private List<PipeControl> pipes = new List<PipeControl>();
    // 管道索引
    private int nowIndex;
    // 生成管道协程
    private Coroutine generateCoroutine;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 开始生成管道
    /// </summary>
    public void StartGenerate()
    {
        for (int i = 0; i < pipes.Count; i++)
        {
            pipes[i].gameObject.SetActive(false);
        }
        generateCoroutine = StartCoroutine(GenerateCoroutine());
    }

    /// <summary>
    /// 生成管道协程
    /// </summary>
    /// <returns></returns>
    private IEnumerator GenerateCoroutine()
    {
        while (true)
        {
            RealGenerate();
            yield return new WaitForSeconds(generateInterval);
        }
    }

    /// <summary>
    /// 真实生成管道
    /// </summary>
    public void RealGenerate()
    {
        PipeControl pc;
        if (pipes.Count < 3)
        {
            GameObject pipe = Instantiate(pipePrefab);
            pc = pipe.GetComponent<PipeControl>();
            pc.SetSpeed(moveSpeed);
            pc.SetLeftXPos(leftXPos);
            pipes.Add(pc);
        }
        else
        {
            pc = pipes[nowIndex];
            pc.gameObject.SetActive(true);
            nowIndex++;
            if (nowIndex >= 3)
            {
                nowIndex = 0;
            }
        }

        float yPos = Random.Range(minY, maxY);
        Vector2 startPos = new Vector2(startXPos, yPos);
        pc.SetPos(startPos);

        int upIndex = Random.Range(0, upPoss.Count);
        Vector2 upPos = upPoss[upIndex];
        int downIndex = Random.Range(0, downPoss.Count);
        Vector2 downPos = downPoss[downIndex];
        pc.SetChildPos(upPos, downPos);

        pc.Move();
    }

    /// <summary>
    /// 停止生成管道
    /// </summary>
    public void StopGenerate()
    {
        StopCoroutine(generateCoroutine);
        for (int i = 0; i < pipes.Count; i++)
        {
            pipes[i].StopMove();
        }
    }
}
