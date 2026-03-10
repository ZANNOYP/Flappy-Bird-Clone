using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityPipeFactory : MonoBehaviour, IPipeFactory
{
    private GameObject pipePrefab;
    // 管道Y坐标最大值
    private float upYpos;
    private float defalutUpYpos;
    // 管道Y坐标最小值
    private float downYpos;
    private float defalutDownYpos;

    private float defaultX;

    private float beforeYpos;

    public IPipe Create()
    {
        GameObject pipeObj = PoolMgr.Instance.Pop(pipePrefab, BeforeActive);
        return pipeObj.GetComponent<Pipe>();
    }

    public void Init(float downYpos, float upYpos, float defalutX, GameObject pipePrefab)
    {
        this.downYpos = downYpos;
        this.upYpos = upYpos;
        this.defaultX = defalutX;
        this.pipePrefab = pipePrefab;
        this.defalutDownYpos = this.downYpos;
        this.defalutUpYpos = this.upYpos;
    }

    private void BeforeActive(GameObject obj)
    {
        IPipe pipe = obj.GetComponent<Pipe>();

        float y = Random.Range(downYpos, upYpos);
        beforeYpos = y;
        downYpos = Mathf.Max(beforeYpos - 1, defalutDownYpos);
        upYpos = Mathf.Min(beforeYpos + 1, defalutUpYpos);

        pipe.SetPos(defaultX, y);
    }
}
